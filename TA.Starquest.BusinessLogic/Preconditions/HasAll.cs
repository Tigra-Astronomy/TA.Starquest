﻿// This file is part of the MS.Gamification project
// 
// File: HasAll.cs  Created: 2016-07-20@11:19
// Last modified: 2016-07-20@13:01

using System.Linq;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.BusinessLogic.Preconditions
    {
    public class HasAll : CompositePredicate<ApplicationUser>
        {
        public override bool Evaluate(ApplicationUser candidate)
            {
            return Subconditions.All(p => p.Evaluate(candidate));
            }
        }
    }