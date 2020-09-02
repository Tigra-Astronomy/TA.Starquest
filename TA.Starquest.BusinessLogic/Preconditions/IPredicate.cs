// This file is part of the MS.Gamification project
// 
// File: IPredicate.cs  Created: 2016-07-20@10:27
// Last modified: 2016-07-20@11:29

namespace TA.Starquest.BusinessLogic.Preconditions
    {
    /// <summary>
    ///     A predicate that can be applied to an instance of type <typeparamref name="T" />to see if it meets some
    ///     condition.
    /// </summary>
    /// <typeparam name="T">The type of the object to be evaluated.</typeparam>
    public interface IPredicate<in T>
        {
        /// <summary>
        ///     Evaluates the predicate against the specified object.
        /// </summary>
        /// <param name="candidate">The instance of <typeparamref name="T" /> being evaluated.</param>
        /// <returns><c>true</c> if the instance satisfies the predicate, <c>false</c> otherwise.</returns>
        bool Evaluate(T candidate);
        }
    }