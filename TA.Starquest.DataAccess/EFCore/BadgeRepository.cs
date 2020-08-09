using System.Collections.Generic;
using System.Linq;
using TA.Starquest.Core;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.EFCore
    {
    public class BadgeRepository : Repository<Badge, int>
        {
        public BadgeRepository(ApplicationDbContext dbContext) : base(dbContext) {}

        public override IEnumerable<PickListItem<int>> PickList =>
            GetAll().Select(p => new PickListItem<int>(p.Id, p.Name));

        }
    }