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
// File: MissionTrackRepository.cs  Last modified: 2020-08-09@21:30 by Tim Long

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TA.Starquest.Core;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.EFCore
    {
    public class MissionTrackRepository : Repository<MissionTrack, int>
        {
        public MissionTrackRepository(DbContext dbContext) : base(dbContext) { }

        public override IEnumerable<PickListItem<int>> PickList
            {
            get
                {
                var query = from track in Context.Set<MissionTrack>()
                            let missionTitle = track.MissionLevel.Mission.Title
                            let missionLevel = track.MissionLevel.Level
                            let trackTitle = track.Name
                            orderby missionTitle
                            orderby missionLevel
                            orderby track.Number
                            select new PickListData
                                {
                                Level = missionLevel,
                                Mission = missionTitle,
                                Track = trackTitle,
                                TrackId = track.Id
                                };
                var sourceData = query.ToList();
                var pickiList = sourceData.Select(p => new PickListItem<int>
                    {
                    Id = p.TrackId,
                    DisplayName = p.ToString()
                    });
                return pickiList;
                }
            }

        public class PickListData
            {
            public int TrackId { get; set; }

            public string Mission { get; set; }

            public string Track { get; set; }

            public int Level { get; set; }

            public override string ToString()
                {
                return $"{Mission} Level {Level}: {Track}";
                }
            }
        }
    }