// This file is part of the MS.Gamification project
// 
// File: UserRepository.cs  Created: 2016-05-10@22:28
// Last modified: 2016-08-05@23:54

using System.Collections.Generic;
using System.Linq;
using TA.Starquest.Core;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.EFCore
    {
    /// <summary>
    ///     Stores all of the registered users, their passwords, claims and other details.
    /// </summary>
    /// <seealso cref="Repository{TEntity,TKey}" />
    public class UserRepository : Repository<StarquestUser, string>
        {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UserRepository" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public UserRepository(ApplicationDbContext dbContext)
            : base(dbContext) {}

        public override IEnumerable<PickListItem<string>> PickList =>
            GetAll().Select(p => new PickListItem<string>(p.Id, $"{p.UserName} <{p.Email}>"));
        }
    }