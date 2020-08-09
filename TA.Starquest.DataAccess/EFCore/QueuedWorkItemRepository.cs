using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using TA.Starquest.Core;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.EFCore {
    public class QueuedWorkItemRepository : Repository<QueuedWorkItem, int>
        {
        public QueuedWorkItemRepository([NotNull] ApplicationDbContext dbContext) : base(dbContext)
            {
            Contract.Requires(dbContext != null);
            }

        public override IEnumerable<PickListItem<int>> PickList => Enumerable.Empty<PickListItem<int>>();
        }
    }