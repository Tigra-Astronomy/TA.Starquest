// This file is part of the MS.Gamification project
// 
// File: MissionBuilder.cs  Created: 2016-11-01@19:37
// Last modified: 2016-12-12@21:11

using System.Collections.Generic;
using System.Threading;
using MS.Gamification.Models;

namespace MS.Gamification.Tests.TestHelpers
    {
    partial class MissionBuilder
        {
        static int uniqueId;
        readonly string awardTitle;
        readonly DataContextBuilder builder;
        readonly int missionId;
        readonly List<MissionTrack> tracks;
        int missionLevel;
        int missionLevelId;
        string missionName;

        public MissionBuilder(DataContextBuilder builder, int missionId = 1)
            {
            this.builder = builder;
            this.missionId = missionId;
            missionLevelId = Interlocked.Increment(ref uniqueId);
            missionLevel = 1;
            missionName = "Unit Test Mission";
            awardTitle = "Unit Tester";
            tracks = new List<MissionTrack>();
            }

        public MissionBuilder WithId(int id)
            {
            missionLevelId = id;
            missionName = $"Unit Test Mission {id}";

            return this;
            }

        public TrackBuilder WithTrack(int trackNumber)
            {
            return new TrackBuilder(this, trackNumber);
            }

        public DataContextBuilder BuildMission()
            {
            builder.WithEntity(new Mission
                {
                Title = "Unit Test Mission",
                Id = missionId
                });
            var level = new MissionLevel
                {
                AwardTitle = awardTitle,
                Id = missionLevelId,
                Level = missionLevel,
                Name = missionName,
                Tracks = tracks,
                MissionId = missionId
                };
            foreach (var track in tracks)
                {
                builder.WithEntity(track.Badge);
                foreach (var challenge in track.Challenges)
                    {
                    // Make sure the challenges are attached to this track and added to the dataset.
                    challenge.MissionTrackId = track.Id;
                    builder.WithEntity(challenge);
                    }
                track.MissionLevelId = missionLevelId;
                builder.WithEntity(track);
                }
            builder.WithEntity(level);
            return builder;
            }

        public MissionBuilder Level(int level)
            {
            missionLevel = level;
            return this;
            }
        }
    }