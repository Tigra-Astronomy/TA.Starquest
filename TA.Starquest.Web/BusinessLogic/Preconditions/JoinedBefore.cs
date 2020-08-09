// This file is part of the MS.Gamification project
// 
// File: JoinedBefore.cs  Created: 2016-07-20@13:06
// Last modified: 2016-07-20@13:19

using System;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.Web.BusinessLogic.Preconditions
    {
    public class JoinedBefore : IPredicate<StarquestUser>
        {
        private readonly DateTime deadline;

        public JoinedBefore(DateTime deadline)
            {
            this.deadline = deadline;
            }

        public bool Evaluate(StarquestUser candidate)
            {
            return candidate.Provisioned < deadline;
            }
        }
    }