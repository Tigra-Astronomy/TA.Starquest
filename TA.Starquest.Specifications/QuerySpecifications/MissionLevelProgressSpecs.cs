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
// File: MissionLevelProgressSpecs.cs  Last modified: 2020-09-01@23:06 by Tim Long

using System.Linq;
using Machine.Specifications;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.DataAccess.QuerySpecifications;

namespace TA.Starquest.Specifications.QuerySpecifications
    {
    [Subject(typeof(MissionLevelProgress), "query")]
    internal class when_retrieving_mission_progress : with_query_specification_context
        {
        private static Mission mission;
        Establish context = () => Context = Builder.WithStandardMission().Build();
        Because of = () => mission = UnitOfWork.Missions.AllSatisfying(new MissionLevelProgress(1)).Single();
        It should_eagerly_load_badges = () => Context.DbContext.Badges.Local.Count.ShouldEqual(3);
        It should_eagerly_load_challenges = () => Context.DbContext.Challenges.Local.Count.ShouldEqual(6);
        It should_eagerly_load_levels = () => Context.DbContext.MissionLevels.Local.Count.ShouldEqual(1);
        It should_eagerly_load_tracks = () => Context.DbContext.MissionTracks.Local.Count.ShouldEqual(3);
        It should_fetch_mission_1 = () => mission.Id.ShouldEqual(1);
        }
    }