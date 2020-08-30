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
// File: LevelHasAssociatedObservations.cs  Last modified: 2020-08-11@14:43 by Tim Long

using System.Linq;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.QuerySpecifications
    {
    /// <summary>
    ///     A query specification that can be used to determine whether a given Mission Level has any
    ///     observations associated with it. The query returns a set of integers, which will be empty if no
    ///     observations were found, or will contain a single element representing the number of
    ///     observations associated with the level. This is designed to be convenient for use with
    ///     <c>Repository.GetMaybe</c>.
    /// </summary>
    public class LevelHasAssociatedObservations : QuerySpecification<Observation, int>
        {
        private readonly int levelId;

        public LevelHasAssociatedObservations(int levelId)
            {
            this.levelId = levelId;
            }

        public override IQueryable<int> GetQuery(IQueryable<Observation> items)
            {
            /*
             * Returns a collection of counts, where each count is the number of observations
             * associated with a mission level. Since the observations are pre-filtered to only
             * those in a single mission level, then the result will either be a single element
             * containing the count of the associated observations, or it will be an empty set
             * if none were found. This can be used directly with IRepository.GetMaybe().
             */
            var query = from observation in items
                        let associatedLevel = observation.Challenge.MissionTrack.MissionLevelId
                        where associatedLevel == levelId
                        group observation by associatedLevel
                        into associatedObservations
                        select associatedObservations.Count();
            return query;
            }
        }
    }