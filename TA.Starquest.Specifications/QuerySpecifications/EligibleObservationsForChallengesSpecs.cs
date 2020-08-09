// This file is part of the MS.Gamification project
// 
// File: EligibleObservationsForChallengesSpecs.cs  Created: 2016-11-01@19:37
// Last modified: 2016-12-12@23:39

using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using MS.Gamification.Areas.Admin.Controllers;
using MS.Gamification.BusinessLogic.Gamification.QuerySpecifications;
using MS.Gamification.Models;
using MS.Gamification.Tests.Controllers;
using MS.Gamification.Tests.TestHelpers;

namespace MS.Gamification.Tests.QuerySpecifications
    {
    class when_fetching_eligible_observations_for_a_set_of_challenges : with_standard_mission<ChallengesController>
        {
        Establish context = () => ControllerUnderTest = ContextBuilder
            .WithRequestingUser("user", "Joe User")
            .WithData(d => d
                    .WithStandardUser("user", "Joe User")
                    .WithStandardUser("other", "Other User")
                    .WithObservation()
                    .ForUserId("user")
                    .ForChallenge(100)
                    .AwaitingModeration()
                    .BuildObservation() // not eligible (unmoderated)
                    .WithObservation().ForUserId("user").ForChallenge(200).Rejected().BuildObservation() // ineligible (rejected)
                    .WithObservation().ForUserId("user").ForChallenge(300).Approved().WithId(999).BuildObservation() // eligible
                    .WithObservation().ForUserId("user").ForChallenge(300).Approved().BuildObservation() // ineligible (duplicate)
                    .WithObservation().ForUserId("other").ForChallenge(200).Approved().BuildObservation()
                // ineligible (wrong user)
            )
            .Build();
        Because of = () =>
            {
            var challenges = UnitOfWork.Challenges.GetAll();
            var specification = new EligibleObservationsForChallenges(challenges, "user");
            observations = UnitOfWork.Observations.AllSatisfying(specification);
            };
        It should_find_only_one_eligible_observation = () => observations.Single().Id.ShouldEqual(999);
        static IEnumerable<Observation> observations;
        }
    }