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
// File: RemindersForObservingSession.cs  Last modified: 2020-08-11@14:43 by Tim Long

using System.Diagnostics.Contracts;
using System.Linq;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.DataAccess.Entities.QueueWorkItems;

namespace TA.Starquest.DataAccess.QuerySpecifications
    {
    internal class RemindersForObservingSession : QuerySpecification<QueuedWorkItem, ObservingSessionReminder>
        {
        private readonly int sessionId;

        public RemindersForObservingSession(int sessionId)
            {
            this.sessionId = sessionId;
            }

        public override IQueryable<ObservingSessionReminder> GetQuery(IQueryable<QueuedWorkItem> items)
            {
            Contract.Requires(items != null);
            Contract.Ensures(Contract.Result<IQueryable<ObservingSessionReminder>>() != null);
            var query = items.OfType<ObservingSessionReminder>()
                .Where(p => p.ObservingSessionId == sessionId);
            return query;
            }
        }
    }