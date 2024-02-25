// This file is part of the MS.Gamification project
// 
// File: HasBadge.cs  Created: 2016-07-20@10:54
// Last modified: 2016-07-21@01:41

using System.Linq;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.BusinessLogic.Preconditions;

/// <summary>
///     A predicate that is <c>true</c> if an application user has been awarded a specified badge.
/// </summary>
public class HasBadge : IPredicate<ApplicationUser>
{
    private readonly int badgeId;

    public HasBadge(int badgeId)
    {
        this.badgeId = badgeId;
    }

    public bool Evaluate(ApplicationUser candidate)
    {
        return candidate.UserBadges.Any(p => p.BadgeId == badgeId);
    }
}