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
// File: with_standard_mission.cs  Last modified: 2020-08-31@18:56 by Tim Long

using Machine.Specifications;
using TA.Starquest.DataAccess.EFCore;

namespace TA.Starquest.Specifications.QuerySpecifications
    {
    internal class with_standard_mission
        {
        Establish context = () => Builder = new QueryTestContextBuilder();
        private Cleanup after = () => Context?.Dispose();
        protected static EntityFrameworkCoreUnitOfWork UnitOfWork => Context.UnitOfWork;
        protected static QueryTestContextBuilder Builder;
        protected static QueryTestContext Context;
        }
    }