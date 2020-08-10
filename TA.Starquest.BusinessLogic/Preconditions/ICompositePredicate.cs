// This file is part of the MS.Gamification project
// 
// File: ICompositePredicate.cs  Created: 2016-07-20@10:52
// Last modified: 2016-07-20@11:26

namespace TA.Starquest.BusinessLogic.Preconditions
    {
    /// <summary>
    ///     A composite predicate that can be applied to an instance of type <typeparamref name="T" />to see if it meets some
    ///     condition.
    /// </summary>
    /// <seealso cref="IPredicate{T}" />
    internal interface ICompositePredicate<T> : IPredicate<T>
        {
        /// <summary>
        ///     Adds a subcondition to the composite predicate.
        /// </summary>
        /// <param name="condition">The subcondition.</param>
        void AddSubcondition(IPredicate<T> condition);
        }
    }