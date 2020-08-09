// This file is part of the MS.Gamification project
// 
// File: MissionLevelRepository.cs  Created: 2016-07-01@20:29
// Last modified: 2016-07-01@20:39

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TA.Starquest.Core;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.EFCore
    {
    internal class MissionLevelRepository : Repository<MissionLevel, int>
        {
        public MissionLevelRepository(DbContext dbContext) : base(dbContext) {}

        public override IEnumerable<PickListItem<int>> PickList
            => GetAll().Select(p => new PickListItem<int>(p.Id, p.Name));
        }
    }