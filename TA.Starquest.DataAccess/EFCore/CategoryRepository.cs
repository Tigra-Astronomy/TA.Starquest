// This file is part of the MS.Gamification project
// 
// File: CategoryRepository.cs  Created: 2016-05-10@22:28
// Last modified: 2016-07-01@20:33

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TA.Starquest.Core;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.EFCore
    {
    public class CategoryRepository : Repository<Category, int>
        {
        public CategoryRepository(DbContext context) : base(context) {}

        public override IEnumerable<PickListItem<int>> PickList
            => GetAll().Select(p => new PickListItem<int>(p.Id, p.Name));
        }
    }