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
// File: ObservationsAwaitingModeration.cs  Last modified: 2020-08-11@14:43 by Tim Long

using System.Linq;
using TA.Starquest.Core;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.DataAccess.Models;

namespace TA.Starquest.DataAccess.QuerySpecifications
    {
    public class ObservationsAwaitingModeration : QuerySpecification<Observation, ModerationQueueItem>
        {
        public override IQueryable<ModerationQueueItem> GetQuery(IQueryable<Observation> items)
            {
            //var query = from item in items
            //            where item.Status == ModerationState.AwaitingModeration
            //            select item;
            var moderationQueue = items
                .Where(p => p.Status == ModerationState.AwaitingModeration)
                .Project().To<ModerationQueueItem>();
            return moderationQueue;
            }
        }
    }