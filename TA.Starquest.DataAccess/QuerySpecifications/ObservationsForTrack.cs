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
// File: ObservationsForTrack.cs  Last modified: 2020-08-11@14:43 by Tim Long

using System.Linq;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.QuerySpecifications
    {
        /// <summary>
        ///     Finds the observations associated with a mission track ID.
        /// </summary>
        public class ObservationsForTrack(int trackId) : QuerySpecification<Observation>
        {
            public override IQueryable<Observation> GetQuery(IQueryable<Observation> items) =>
                from observation in items
                let associatedTrack = observation.Challenge.MissionTrack.Id
                where associatedTrack == trackId
                select observation;
        }
    }