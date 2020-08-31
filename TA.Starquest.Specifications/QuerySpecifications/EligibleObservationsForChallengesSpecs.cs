// This file is part of the MS.Gamification project
// 
// File: EligibleObservationsForChallengesSpecs.cs  Created: 2016-11-01@19:37
// Last modified: 2016-12-12@23:39

using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.DataAccess.QuerySpecifications;

namespace TA.Starquest.Specifications.QuerySpecifications
    {
    class when_fetching_eligible_observations_for_a_set_of_challenges : with_query_specification_context
        {
        private Establish context = () => Context = Builder.WithStandardMission()
            //.WithRequestingUser("user", "Joe User")
            .WithUser("user", "Joe User") // User of interest
            .WithUser("other", "Other User") // Disinterested user
            .WithObservationAwaitingModeration(1, "user", 1111) // ineligible (not moderated)
            .WithRejectedObservation(2, "user", 1112) // ineligible (rejected)
            .WithApprovedObservation(3, "user", 1121) // eligible, challenge 1121
            .WithApprovedObservation(4, "other", 1111) // ineligible (wrong user)
            .WithApprovedObservation(5, "user", 1122) // eligible, challenge 1122
            .Build();
        private Because of = () =>
            {
            var challenges = UnitOfWork.Challenges.GetAll();
            var specification = new EligibleObservationsForChallenges(challenges, "user");
            observations = UnitOfWork.Observations.AllSatisfying(specification);
            };
        private It should_find_observations_3_and_5 = () => observations.Select(p => p.Id).SequenceEqual(new[] {3, 5});
        static IEnumerable<Observation> observations;
        }
    }