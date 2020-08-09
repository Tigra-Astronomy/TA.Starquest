// This file is part of the MS.Gamification project
// 
// File: HasAny.cs  Created: 2016-07-20@11:10
// Last modified: 2016-07-20@13:01

using System.Linq;
using TA.Starquest.Web.DataAccess.Entities;

namespace TA.Starquest.Web.BusinessLogic.Preconditions
    {
    /// <summary>
    ///     A composite predicate that is true if any of its subconditions are true (logical OR).
    /// </summary>
    /// <seealso cref="ICompositePredicate{T}" />
    internal class HasAny : CompositePredicate<ApplicationUser>
        {
        public override bool Evaluate(ApplicationUser candidate)
            {
            return Subconditions.Any(p => p.Evaluate(candidate));
            }
        }
    }