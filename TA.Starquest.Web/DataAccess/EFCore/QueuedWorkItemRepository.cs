using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using TA.Starquest.Core;
using TA.Starquest.Web.Data;
using TA.Starquest.Web.DataAccess.Entities;

namespace TA.Starquest.Web.DataAccess.DataEntities {
    public class QueuedWorkItemRepository : Repository<QueuedWorkItem, int>
        {
        public QueuedWorkItemRepository([NotNull] ApplicationDbContext dbContext) : base(dbContext)
            {
            Contract.Requires(dbContext != null);
            }

        public override IEnumerable<PickListItem<int>> PickList => Enumerable.Empty<PickListItem<int>>();
        }
    }