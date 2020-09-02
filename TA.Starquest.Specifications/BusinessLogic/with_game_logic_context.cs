// This file is part of the MS.Gamification project
// 
// File: with_game_logic_context.cs  Created: 2016-11-01@19:37
// Last modified: 2017-05-17@19:25

using System.Collections.Generic;
using Machine.Specifications;
using TA.Starquest.BusinessLogic.Preconditions;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.Specifications.BusinessLogic
    {
    class with_game_logic_context
        {
        protected static GameLogicContextBuilder GameContextBuilder;
        protected static GameLogicContext GameContext;
        Cleanup after = () =>
            {
            GameContext = null;
            GameContextBuilder = null;
            };
        Establish context = () => GameContextBuilder = new GameLogicContextBuilder();

        protected static ApplicationUser User => GameContext.User;

        protected static LevelPreconditionParser Parser => GameContext.Parser;

        protected static IPredicate<ApplicationUser> Precondition => GameContext.Precondition;

        protected static IEnumerable<Badge> Badges => GameContext.Badges;
        }
    }