﻿// This file is part of the TA.Starquest project
// 
// Copyright © 2015-2020 Tigra Astronomy, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: GameLogicContext.cs  Last modified: 2020-09-02@14:34 by Tim Long

using System.Collections.Generic;
using TA.Starquest.BusinessLogic.Preconditions;
using TA.Starquest.DataAccess.Entities;
using TA.Utils.Core.Diagnostics;

namespace TA.Starquest.Specifications.BusinessLogic
    {
    class GameLogicContext
        {
            public LevelPreconditionParser Parser { get; set; } = new(new DegenerateLoggerService());

            public IPredicate<ApplicationUser> Precondition { get; set; }

        public ApplicationUser User { get; set; }

        public IEnumerable<Badge> Badges { get; set; }
        }
    }