// This file is part of the MS.Gamification project
// 
// File: LevelPreconditionParser.cs  Created: 2016-07-20@11:33
// Last modified: 2016-07-21@02:04

using System;
using System.Linq;
using System.Xml.Linq;
using TA.Starquest.DataAccess.Entities;
using TA.Utils.Core.Diagnostics;

namespace TA.Starquest.BusinessLogic.Preconditions
    {
    /// <summary>
    ///     Parses level precondition XML and builds a predicate expression tree that can be applied to a user to see if
    ///     the level is unlocked for that user.
    /// </summary>
    public class LevelPreconditionParser
        {
        private static readonly XNamespace xmlns = "http://tigra-astronomy.com/starquest/LevelPreconditionSchema.xsd";
        private readonly ILog log;

        public LevelPreconditionParser(ILog log)
        {
            this.log = log;
        }

        public IPredicate<ApplicationUser> ParsePreconditionXml(string xml)
        {
            try
            {
                var rootElement = XElement.Parse(xml, LoadOptions.PreserveWhitespace);
                //var rootElement = parsedXml.Element(xmlns + "LevelPrecondition");
                var rootPredicate = rootElement.Descendants().First();
                return CreatePredicate(rootPredicate);
            }
            catch (Exception e)
            {
                log.Error()
                    .Exception(e)
                    .Message("Unable to parse precondition XML; using AlwaysFalse predicate")
                    .Property(nameof(xml), xml)
                    .Write();
                return CompositePredicate<ApplicationUser>.AlwaysFalse;
            }
        }

        private IPredicate<ApplicationUser> CreatePredicate(XElement predicateXml)
            {
            var predicateType = predicateXml.Name.LocalName;
            switch (predicateType)
            {
                case "HasBadge":
                    return CreateHasBadgePredicate(predicateXml);
                case "JoinedBefore":
                    return CreateJoinedBeforePredicate(predicateXml);
                case "HasAny":
                    return CreateCompositePredicate(new HasAny(), predicateXml);
                case "HasAll":
                    return CreateCompositePredicate(new HasAll(), predicateXml);
                default:
                    log.Warn()
                        .Message("Unrecognised predicate type {predicateType} - using AlwaysFalse instead", predicateType)
                        .Property(nameof(predicateXml), predicateXml)
                        .Write();
                    return CompositePredicate<ApplicationUser>.AlwaysFalse;
            }
            }

            private IPredicate<ApplicationUser> CreateJoinedBeforePredicate(XElement predicateXml)
            {
                try
                {
                    var dateAttribute = predicateXml.Attribute("date");
                    var deadline = DateTime.Parse(dateAttribute.Value);
                    return new JoinedBefore(deadline);
                }
                catch (Exception e)
                {
                    log.Warn()
                        .Exception(e)
                        .Message("Failed to create JoinedBefore predicate from {predicateXml}, using AlwaysFalse instead", predicateXml)
                        .Write();
                    return CompositePredicate<ApplicationUser>.AlwaysFalse;
                }
            }

            /// <summary>
            ///     Recursively creates a composite predicate.
            /// </summary>
            /// <param name="predicate">The predicate already built.</param>
            /// <param name="predicateXml">The predicate XML.</param>
            private IPredicate<ApplicationUser> CreateCompositePredicate(
                ICompositePredicate<ApplicationUser> predicate,
                XElement                             predicateXml)
            {
                try
                {
                    var children = predicateXml.Elements();
                    foreach (var childElement in children)
                    {
                        var childPredicate = CreatePredicate(childElement); // Recursion!
                        predicate.AddSubcondition(childPredicate);
                    }

                    return predicate;
                }
                catch (Exception e)
                {
                    log.Error()
                        .Exception(e)
                        .Message("Error parsing composite predicate from {predicateXml}: {message}", predicateXml, e.Message)
                        .Write();
                    return CompositePredicate<ApplicationUser>.AlwaysFalse;
                }
            }

            private IPredicate<ApplicationUser> CreateHasBadgePredicate(XElement predicateXml)
            {
                try
                {
                    var idAttribute = predicateXml.Attribute("id");
                    var badgeId = int.Parse(idAttribute.Value);
                    return new HasBadge(badgeId);
                }
                catch (Exception e)
                {
                    log.Error()
                        .Exception(e)
                        .Message("Failed to create HasBadge predicate from {predicateXml}: {message}", predicateXml, e.Message)
                        .Write();
                    return CompositePredicate<ApplicationUser>.AlwaysFalse;
                }
            }
        }
    }