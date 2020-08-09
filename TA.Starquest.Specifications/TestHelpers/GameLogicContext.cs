// This file is part of the MS.Gamification project
// 
// File: GameLogicContext.cs  Created: 2017-05-17@19:21
// Last modified: 2017-05-17@19:21

using System.Collections.Generic;
using MS.Gamification.BusinessLogic.Gamification.Preconditions;
using MS.Gamification.Models;

namespace MS.Gamification.Tests.TestHelpers
    {
    class GameLogicContext
        {
        public LevelPreconditionParser Parser { get; set; } = new LevelPreconditionParser();

        public IPredicate<ApplicationUser> Precondition { get; set; }

        public ApplicationUser User { get; set; }

        public IEnumerable<Badge> Badges { get; set; }
        }
    }