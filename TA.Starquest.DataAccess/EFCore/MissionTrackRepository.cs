// This file is part of the MS.Gamification project
// 
// File: MissionTrackRepository.cs  Created: 2016-07-09@21:09
// Last modified: 2016-07-09@23:23

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TA.Starquest.Core;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.EFCore
    {
    public class MissionTrackRepository : Repository<MissionTrack, int>
        {
        public MissionTrackRepository(DbContext dbContext) : base(dbContext) {}

        public override IEnumerable<PickListItem<int>> PickList
            {
            get
                {
                var query = from track in Context.Set<MissionTrack>()
                            let missionTitle = track.MissionLevel.Mission.Title
                            let missionLevel = track.MissionLevel.Level
                            let trackTitle = track.Name
                            orderby missionTitle ascending
                            orderby missionLevel ascending
                            orderby track.Number ascending
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