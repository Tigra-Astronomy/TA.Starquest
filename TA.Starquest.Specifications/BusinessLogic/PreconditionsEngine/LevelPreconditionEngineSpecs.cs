// This file is part of the MS.Gamification project
// 
// File: LevelPreconditionEngineSpecs.cs  Created: 2016-07-21@04:50
// Last modified: 2016-07-21@05:04

using System;
using Machine.Specifications;
using TA.Starquest.BusinessLogic.Preconditions;

namespace TA.Starquest.Specifications.BusinessLogic.PreconditionsEngine
    {

    #region Context base classes
    #endregion Context base classes

    [Subject(typeof(LevelPreconditionParser))]
    class when_parsing_a_simple_has_badge_precondition : with_game_logic_context
        {
        Establish context = () => GameContext = GameContextBuilder
            .WithPreconditionResource("HasBadge-1.xml")
            .Build();
        It should_return_the_expected_predicate_type = () => Precondition.ShouldBeOfExactType<HasBadge>();
        }

    [Subject(typeof(LevelPreconditionParser))]
    class when_parsing_a_simple_joined_before_precondition : with_game_logic_context
    {
        Establish context = () => GameContext = GameContextBuilder
            .WithPreconditionResource("JoinedBefore-2016-07-20-Midnight.xml")
            .Build();
        It should_return_the_expected_predicate_type = () => Precondition.ShouldBeOfExactType<JoinedBefore>();
    }

    [Subject(typeof(LevelPreconditionParser))]
    class when_parsing_a_composite_has_any_precondition : with_game_logic_context
    {
        Establish context = () => GameContext = GameContextBuilder
            .WithPreconditionResource("HasAny-1-2-4.xml")
            .Build();
        It should_return_the_expected_predicate_type = () => Precondition.ShouldBeOfExactType<HasAny>();
    }

    [Subject(typeof(LevelPreconditionParser))]
    class when_parsing_a_composite_has_all_precondition : with_game_logic_context
    {
        Establish context = () => GameContext = GameContextBuilder
            .WithPreconditionResource("HasAll-1-2-4.xml")
            .Build();
        It should_return_the_expected_predicate_type = () => Precondition.ShouldBeOfExactType<HasAll>();
    }

    [Subject(typeof(LevelPreconditionParser))]
    class when_applying_a_badge_precondition_to_a_user_who_does_not_have_that_badge : with_game_logic_context
    {
        Establish context = () => GameContext = GameContextBuilder
            .WithPreconditionResource("HasBadge-1.xml")
            .WithUserAwardedBadges(2, 3)
            .Build();
        It should_not_satisfy_the_condition = () => User.SatisfiesPrecondition(Precondition).ShouldBeFalse();
    }

    [Subject(typeof(LevelPreconditionParser))]
    class when_applying_a_badge_precondition_to_a_user_who_has_that_badge : with_game_logic_context
    {
        Establish context = () => GameContext = GameContextBuilder
            .WithPreconditionResource("HasBadge-1.xml")
            .WithUserAwardedBadges(1, 3)
            .Build();
        It should_satisfy_the_condition = () => User.SatisfiesPrecondition(Precondition).ShouldBeTrue();
    }

    [Subject(typeof(LevelPreconditionParser))]
    class when_applying_a_has_all_precondition_to_a_user_who_has_all_the_badges : with_game_logic_context
    {
        Establish context = () => GameContext = GameContextBuilder
            .WithPreconditionResource("HasAll-1-2-4.xml")
            .WithUserAwardedBadges(1, 2, 3, 4)
            .Build();
        It should_satisfy_the_condition = () => User.SatisfiesPrecondition(Precondition).ShouldBeTrue();
    }

    [Subject(typeof(LevelPreconditionParser))]
    class when_applying_a_has_all_precondition_to_a_user_who_lacks_one_badge : with_game_logic_context
    {
        Establish context = () => GameContext = GameContextBuilder
            .WithPreconditionResource("HasAll-1-2-4.xml")
            .WithUserAwardedBadges(1, 3, 4)
            .Build();
        It should_not_satisfy_the_condition = () => User.SatisfiesPrecondition(Precondition).ShouldBeFalse();
    }

    [Subject(typeof(LevelPreconditionParser))]
    class when_applying_a_has_any_badge_precondition_to_a_user_who_has_one_of_the_badges : with_game_logic_context
    {
        Establish context = () => GameContext = GameContextBuilder
            .WithPreconditionResource("HasAny-1-2-4.xml")
            .WithUserAwardedBadges(3, 4)
            .Build();
        It should_satisfy_the_condition = () => User.SatisfiesPrecondition(Precondition).ShouldBeTrue();
    }

    [Subject(typeof(LevelPreconditionParser))]
    class when_applying_a_has_any_badge_precondition_to_a_user_who_has_none_of_the_badges : with_game_logic_context
    {
        Establish context = () => GameContext = GameContextBuilder
            .WithPreconditionResource("HasAny-1-2-4.xml")
            .WithUserAwardedBadges(3, 5)
            .Build();
        It should_not_satisfy_the_condition = () => User.SatisfiesPrecondition(Precondition).ShouldBeFalse();
    }

    [Subject(typeof(LevelPreconditionParser))]
    class when_applying_a_date_joined_precondition_and_the_user_joined_before_the_deadline : with_game_logic_context
    {
        Establish context = () => GameContext = GameContextBuilder
            .WithPreconditionResource("JoinedBefore-2016-07-20-Midnight.xml")
            .WithUserProvisionedOn(new DateTime(2016, 07, 19, 23, 59, 59))
            .Build();
        It should_satisfy_the_condition = () => User.SatisfiesPrecondition(Precondition).ShouldBeTrue();
    }

    [Subject(typeof(LevelPreconditionParser))]
    class when_applying_a_date_joined_precondition_and_the_user_joined_exactly_at_the_deadline : with_game_logic_context
    {
        Establish context = () => GameContext = GameContextBuilder
            .WithPreconditionResource("JoinedBefore-2016-07-20-Midnight.xml")
            .WithUserProvisionedOn(new DateTime(2016, 07, 20, 0, 0, 0))
            .Build();
        It should_not_satisfy_the_condition = () => User.SatisfiesPrecondition(Precondition).ShouldBeFalse();
    }
}