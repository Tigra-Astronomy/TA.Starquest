// This file is part of the MS.Gamification project
// 
// File: CompositePredicate.cs  Created: 2016-07-20@11:21
// Last modified: 2016-07-20@22:41

using System.Collections.Generic;

namespace TA.Starquest.Web.BusinessLogic.Preconditions
    {
    /// <summary>
    ///     A composite predicate that can contain zero or more subconditions.
    /// </summary>
    /// <typeparam name="T">The type of object that the predicate can be applied to.</typeparam>
    internal abstract class CompositePredicate<T> : ICompositePredicate<T>
        {
        protected readonly List<IPredicate<T>> Subconditions = new List<IPredicate<T>>();

        public static IPredicate<T> AlwaysFalse { get; } = new False<T>();

        /// <summary>
        ///     Adds a subcondition to the composite predicate.
        /// </summary>
        /// <param name="condition">The subcondition.</param>
        public void AddSubcondition(IPredicate<T> condition)
            {
            Subconditions.Add(condition);
            }

        public abstract bool Evaluate(T candidate);

        internal class False<TQ> : IPredicate<TQ>
            {
            public bool Evaluate(TQ candidate)
                {
                return false;
                }
            }
        }
    }