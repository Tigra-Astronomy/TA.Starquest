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
// File: LevelExistsInMission.cs  Last modified: 2020-08-11@14:43 by Tim Long

using System.Linq;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.QuerySpecifications
    {
    public class LevelExistsInMission : QuerySpecification<MissionLevel, int>
        {
        private readonly int levelNumber;
        private readonly int missionId;

        public LevelExistsInMission(int levelNumber, int missionId)
            {
            this.levelNumber = levelNumber;
            this.missionId = missionId;
            }

        public override IQueryable<int> GetQuery(IQueryable<MissionLevel> items)
            {
            var query = from level in items
                        where level.MissionId == missionId
                        where level.Level == levelNumber
                        select level.Level;
            return query;
            }
        }
    }