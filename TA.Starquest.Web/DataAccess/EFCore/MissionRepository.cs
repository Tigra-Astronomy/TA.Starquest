using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MS.Gamification.Models;
using TA.Starquest.Core;

namespace TA.Starquest.Web.DataAccess.DataEntities
    {
    public class MissionRepository : Repository<Mission, int>
        {
        public MissionRepository(DbContext dbContext) : base(dbContext) {}

        public override IEnumerable<PickListItem<int>> PickList
            => GetAll().Select(p => new PickListItem<int>(p.Id, p.Title));
        }
    }