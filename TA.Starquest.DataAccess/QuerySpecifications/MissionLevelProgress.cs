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
// File: MissionLevelProgress.cs  Last modified: 2020-08-11@14:43 by Tim Long

using System.Linq;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.QuerySpecifications
    {
    /// <summary>
    /// A query which specifies a specific mission and its related
    /// levels, badges and challenges, all of which are eagerly loaded.
    /// </summary>
    public class MissionLevelProgress : QuerySpecification<Mission>
        {
        private readonly int missionId;

        public MissionLevelProgress(int missionId)
            {
            this.missionId = missionId;
            FetchStrategy.Include(p => p.MissionLevels);
            FetchStrategy.Include(p => p.MissionLevels
                .Select(q => q.Tracks
                    .Select(r => r.Badge)));
            FetchStrategy.Include(p => p.MissionLevels
                .Select(q => q.Tracks
                    .Select(r => r.Challenges
                        .Select(s => s.Category))));
            }

        public override IQueryable<Mission> GetQuery(IQueryable<Mission> items)
            {
            var query = from item in items
                        where item.Id == missionId
                        select item;
            return query;
            }
        }
    }