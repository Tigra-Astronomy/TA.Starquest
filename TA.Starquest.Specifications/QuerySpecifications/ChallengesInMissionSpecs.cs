using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.DataAccess.QuerySpecifications;

namespace TA.Starquest.Specifications.QuerySpecifications
{
class when_querying_the_challenges_for_a_mission_level : with_standard_mission
    {
    Establish context = () => Context = Builder.WithStandardMission().Build();
    // Standard Mission has ID=1
    Because of = () => results = UnitOfWork.Challenges.AllSatisfying(new ChallengesInMissionLevel(11));
    It should_find_6_challenges = () => results.Count().ShouldEqual(6);
    static IEnumerable<Challenge> results;
    }
}
