// This file is part of the MS.Gamification project
// 
// File: ChallengeRepository.cs  Created: 2016-05-10@22:28
// Last modified: 2016-08-05@23:49

using System.Collections.Generic;
using System.Linq;
using MS.Gamification.Models;
using TA.Starquest.Core;
using TA.Starquest.Web.Data;

namespace TA.Starquest.Web.DataAccess.DataEntities
    {
    /// <summary>
    ///     Stores the challenges.
    /// </summary>
    /// <seealso cref="Repository{TEntity,TKey}" />
    public class ChallengeRepository : Repository<Challenge, int>
        {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ChallengeRepository" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ChallengeRepository(ApplicationDbContext dbContext) : base(dbContext) {}

        public override IEnumerable<PickListItem<int>> PickList =>
            GetAll().Select(p => new PickListItem<int>(p.Id, p.Name));
        }
    }