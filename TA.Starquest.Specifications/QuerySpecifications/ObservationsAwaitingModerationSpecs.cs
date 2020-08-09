// This file is part of the MS.Gamification project
// 
// File: ObservationsAwaitingModerationSpecs.cs  Created: 2016-05-26@03:51
// Last modified: 2016-08-18@04:55

using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using MS.Gamification.BusinessLogic.Gamification.QuerySpecifications;
using MS.Gamification.Models;
using MS.Gamification.ViewModels.Moderation;

namespace MS.Gamification.Tests.QuerySpecifications
    {
    /*
     * Query Specification: Observations Awaiting Moderation
     * Given:
     *  A collection of observations, one of which is in Pending status
     * When:
     *  the query is run
     * Then:
     *  it should produce one result
     *  The one result should be in Pending status
     *  
     * When:
     *  There are no observations in Pending state
     * Then:
     *  It should produce an empty result
     */

    [Subject(typeof(ObservationsAwaitingModeration))]
    class when_querying_observations_and_there_is_one_observation_in_pending_state
        {
        Establish context = () =>
            {
            var user = new ApplicationUser {Id = "darth", Email = "Darth@deathstar.com", UserName = "Darth Vader"};
            var obsTime = new DateTime(2016, 08, 18, 0, 0, 0, DateTimeKind.Utc);
            var challenge = new Challenge {Id = 1, Name = "Destroy the rebel alliance"};
            Observations = new List<Observation>
                {
                new Observation
                    {
                    Id = 1, User = user, Challenge = challenge, ObservationDateTimeUtc = obsTime,
                    Status = ModerationState.Approved
                    },
                new Observation
                    {
                    Id = 2, User = user, Challenge = challenge, ObservationDateTimeUtc = obsTime,
                    Status = ModerationState.AwaitingModeration
                    },
                new Observation
                    {
                    Id = 3, User = user, Challenge = challenge, ObservationDateTimeUtc = obsTime,
                    Status = ModerationState.Rejected
                    }
                };
            };

        Because of = () =>
            {
            var specification = new ObservationsAwaitingModeration();
            var items = Observations.AsQueryable();
            var query = specification.GetQuery(items);
            Results = query.ToList();
            };

        It should_produce_one_result = () => Results.Count.ShouldEqual(1);
        It should_be_awaiting_moderation = () => Results.Single().ObservationId.ShouldEqual(2);
        static List<Observation> Observations;
        static List<ModerationQueueItem> Results;
        }

    [Subject(typeof(ObservationsAwaitingModeration))]
    class when_querying_observations_and_there_are_no_observation_in_pending_state
        {
        Establish context = () => Observations = new List<Observation>
            {
            new Observation {Id = 1, Status = ModerationState.Approved},
            new Observation {Id = 3, Status = ModerationState.Rejected}
            };

        Because of = () => Results = new ObservationsAwaitingModeration()
            .GetQuery(Observations.AsQueryable())
            .ToList();

        It should_produce_no_results = () => Results.Count.ShouldEqual(0);
        static List<Observation> Observations;
        static List<ModerationQueueItem> Results;
        }
    }