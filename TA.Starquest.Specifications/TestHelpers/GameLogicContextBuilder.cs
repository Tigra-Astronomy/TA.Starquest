// This file is part of the MS.Gamification project
// 
// File: GameLogicContextBuilder.cs  Created: 2016-07-21@02:08
// Last modified: 2016-07-21@04:24

using System;
using System.Collections.Generic;
using System.Linq;
using MS.Gamification.BusinessLogic.Gamification.Preconditions;
using MS.Gamification.Models;

namespace MS.Gamification.Tests.TestHelpers
    {
    class GameLogicContextBuilder
        {
        readonly List<Badge> badges = new List<Badge>();
        readonly LevelPreconditionParser parser = new LevelPreconditionParser();
        IPredicate<ApplicationUser> precondition = CompositePredicate<ApplicationUser>.AlwaysFalse;
        ApplicationUser user = new ApplicationUser();

        public GameLogicContextBuilder WithPrecondition(string xml)
            {
            precondition = parser.ParsePreconditionXml(xml);
            return this;
            }

        public GameLogicContextBuilder WithPreconditionResource(string resourceName)
            {
            var xml = TestData.FromEmbeddedResource(resourceName);
            return WithPrecondition(xml);
            }

        public GameLogicContext Build()
            {
            return new GameLogicContext
                {
                Parser = parser,
                Precondition = precondition,
                User = user,
                Badges = badges
                };
            }

        public GameLogicContextBuilder WithUserAwardedBadges(params int[] badgesAwarded)
            {
            var userId = new Guid().ToString();
            var newUser = new ApplicationUser
                {
                Id = userId,
                Email = $"{userId}@nowhere.com",
                UserName = $"Test user {userId}"
                };
            // Add the awarded badges to the new user and the badges 'repository'
            // being careful to maintain consistency and avoid duplicates.
            foreach (var awardedBadgeId in badgesAwarded)
                {
                var existingBadges = badges.Where(p => p.Id == awardedBadgeId);
                var badgeToAdd = existingBadges.FirstOrDefault() ??
                                 new Badge
                                     {
                                     Id = awardedBadgeId, Name = $"Badge {awardedBadgeId}",
                                     ImageIdentifier = $"Badge-{awardedBadgeId}-identifier"
                                     };
                newUser.Badges.Add(badgeToAdd);
                if (!existingBadges.Any())
                    badges.Add(badgeToAdd);
                }
            user = newUser;
            return this;
            }

        public GameLogicContextBuilder WithUserProvisionedOn(DateTime provisioningDate)
            {
            user.Provisioned = provisioningDate;
            return this;
            }
        }
    }