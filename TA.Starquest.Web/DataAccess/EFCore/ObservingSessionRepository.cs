// This file is part of the MS.Gamification project
// 
// File: ObservingSessionRepository.cs  Created: 2017-05-16@19:32
// Last modified: 2017-05-16@19:35

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TA.Starquest.Core;
using TA.Starquest.Web.DataAccess.Entities;

namespace TA.Starquest.Web.DataAccess.DataEntities
    {
    public class ObservingSessionRepository : Repository<ObservingSession, int>
        {
        public ObservingSessionRepository(DbContext context) : base(context) { }

        public override IEnumerable<PickListItem<int>> PickList =>
            GetAll().Select(p => new PickListItem<int>(p.Id, $"{p.StartsAt:s} {p.Title}"));
        }
    }