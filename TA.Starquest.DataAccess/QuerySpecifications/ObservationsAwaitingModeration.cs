// This file is part of the MS.Gamification project
// 
// File: ObservationsAwaitingModeration.cs  Created: 2016-07-09@20:14
// Last modified: 2016-08-18@05:00

using System.Linq;
using TA.Starquest.Core;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.DataAccess.Models;

namespace TA.Starquest.DataAccess.QuerySpecifications
    {
    public class ObservationsAwaitingModeration : QuerySpecification<Observation, ModerationQueueItem>
        {
        public ObservationsAwaitingModeration()
            {
            }

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