using System.Linq;
using Machine.Specifications;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.DataAccess.QuerySpecifications;
using TA.Utils.Core;

namespace TA.Starquest.Specifications.QuerySpecifications
    {
    [Subject(typeof(LevelExistsInMission), "query")]
    internal class when_retrieving_levels_for_a_mission : with_query_specification_context
        {
        Establish context = () => Context=Builder.WithStandardMission().Build();
        Because of = () => maybeResult = UnitOfWork.MissionLevels.GetMaybe(new LevelExistsInMission(1,1));
        It should_produce_a_result = () => maybeResult.Any().ShouldBeTrue();
        It should_fetch_mission_1_level_1 = () => maybeResult.Single().Level.ShouldEqual(1);
        private static Maybe<MissionLevel> maybeResult;
        }
    }