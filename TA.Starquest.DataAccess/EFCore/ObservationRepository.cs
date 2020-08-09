// This file is part of the MS.Gamification project
// 
// File: ObservationRepository.cs  Created: 2016-04-22@01:14
// Last modified: 2016-04-22@01:15 by Fern

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TA.Starquest.Core;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.EFCore
    {
    public class ObservationRepository : Repository<Observation,int>
        {
        public ObservationRepository(DbContext context) : base(context) {}
        public override IEnumerable<PickListItem<int>> PickList => new List<PickListItem<int>>();
        }
    }