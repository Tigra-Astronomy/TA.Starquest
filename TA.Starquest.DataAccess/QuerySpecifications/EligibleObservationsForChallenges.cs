// This file is part of the TA.Starquest project
// 
// Copyright © 2015-2020 Tigra Astronomy, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: EligibleObservationsForChallenges.cs  Last modified: 2020-08-11@14:43 by Tim Long

using System.Collections.Generic;
using System.Linq;
using TA.Starquest.Core.Extensions;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.QuerySpecifications
    {
    internal class EligibleObservationsForChallenges : QuerySpecification<Observation>
        {
        private readonly IEnumerable<Challenge> challenges;
        private readonly string userId;

        public EligibleObservationsForChallenges(IEnumerable<Challenge> challenges, string userId)
            {
            this.challenges = challenges;
            this.userId = userId;
            }

        public override IQueryable<Observation> GetQuery(IQueryable<Observation> items)
            {
            var approvedObservationsForUser = from observation in items
                                              where observation.UserId == userId
                                              where observation.Status == ModerationState.Approved
                                              orderby observation.ObservationDateTimeUtc
                                              select observation;
            var eligibleObservations = from challenge in challenges
                                       join observation in approvedObservationsForUser
                                           on challenge.Id equals observation.ChallengeId
                                       select observation;
            return eligibleObservations.DistinctBy(p => p.ChallengeId).AsQueryable();
            }
        }
    }