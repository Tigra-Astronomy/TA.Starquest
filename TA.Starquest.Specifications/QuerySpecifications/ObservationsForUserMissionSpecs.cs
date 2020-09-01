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
// File: ObservationsForUserMissionSpecs.cs  Last modified: 2020-08-31@20:02 by Tim Long

using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.DataAccess.QuerySpecifications;
using TA.Starquest.Specifications.QuerySpecifications;

namespace MS.Gamification.Tests.QuerySpecifications
    {
    [Subject(typeof(ObservationsForUserMission))]
    class when_fetching_observations_for_a_users_who_has_observed_multiple_missions : with_query_specification_context
        {
        static IEnumerable<Observation> results;
        Establish context = () => Context = Builder.WithStandardMission()
            .WithUser("user", "Joe User")
            .WithUser("other", "Anonymous")
            .WithObservation(1, "user", 1111)
            .WithObservation(2, "user", 1121)
            .WithObservation(3, "other", 1131)
            .Build();
        Because of = () =>
            results = UnitOfWork.Observations.AllSatisfying(new ObservationsForUserMission("user", 1));
        It should_fetch_two_observations = () => results.Count().ShouldEqual(2);
        It should_fetch_observations_1_and_2 = () => 
            results.Select(p => p.Id).SequenceEqual(new[] {1, 2});
        }
    }