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
// File: ObservationsForUserMission.cs  Last modified: 2020-08-11@14:43 by Tim Long

using System.Linq;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.QuerySpecifications
    {
    /// <summary>
    ///     Specifies the set of observations submitted by a given user against the given Mission ID.
    ///     Eagerly loads the Challenge and Mission Track for each observation.
    /// </summary>
    /// <seealso cref="QuerySpecification{T}" />
    public class ObservationsForUserMission : QuerySpecification<Observation>
        {
        private readonly int missionId;
        private readonly string userId;

        public ObservationsForUserMission(string userId, int missionId)
            {
            this.userId = userId;
            this.missionId = missionId;
            FetchStrategy.Include(p => p.Challenge.MissionTrack);
            }

        public override IQueryable<Observation> GetQuery(IQueryable<Observation> items)
            {
            var observations = from observation in items
                               where observation.UserId == userId
                               where observation.Challenge.MissionTrack.MissionLevel.MissionId == missionId
                               orderby observation.ObservationDateTimeUtc
                               select observation;
            return observations;
            }
        }
    }