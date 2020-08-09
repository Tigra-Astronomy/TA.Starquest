using System.Collections.Generic;
using System.Linq;
using MS.Gamification.Models;
using TA.Starquest.Core;
using TA.Starquest.Web.Data;

namespace TA.Starquest.Web.DataAccess.DataEntities
    {
    public class BadgeRepository : Repository<Badge, int>
        {
        public BadgeRepository(ApplicationDbContext dbContext) : base(dbContext) {}

        public override IEnumerable<PickListItem<int>> PickList =>
            GetAll().Select(p => new PickListItem<int>(p.Id, p.Name));

        }
    }