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
// File: QueuedWorkItemRepository.cs  Last modified: 2020-08-09@21:30 by Tim Long

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using TA.Starquest.Core;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.EFCore
    {
    public class QueuedWorkItemRepository : Repository<QueuedWorkItem, int>
        {
        public QueuedWorkItemRepository([NotNull] ApplicationDbContext dbContext) : base(dbContext)
            {
            Contract.Requires(dbContext != null);
            }

        public override IEnumerable<PickListItem<int>> PickList => Enumerable.Empty<PickListItem<int>>();
        }
    }