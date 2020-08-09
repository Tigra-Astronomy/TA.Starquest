// This file is part of the MS.Gamification project
// 
// File: DataContextBuilder.cs  Created: 2017-05-16@17:37
// Last modified: 2017-05-19@22:39

using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using Effort.Extra;
using Microsoft.AspNet.Identity.EntityFramework;
using MS.Gamification.DataAccess;
using MS.Gamification.Models;

namespace MS.Gamification.Tests.TestHelpers
    {
    class DataContextBuilder
        {
        protected readonly ObjectData data = new ObjectData(TableNamingStrategy.Pluralised);
        protected readonly EffortUnitOfWorkBuilder uowBuilder = new EffortUnitOfWorkBuilder();

        public IUnitOfWork UnitOfWork { get; internal set; }

        public DbContext DataContext => uowBuilder.DataContext;

        public DbConnection DataConnection => uowBuilder.DataConnection;

        /// <summary>
        ///     Adds a user to the identity store and assigns the Moderator role.
        /// </summary>
        /// <param name="id">The user's unique identifier.</param>
        /// <param name="username">The user's login name.</param>
        /// <returns>
        ///     A reference to this <see cref="ControllerContextBuilder{TController}" /> that may be
        ///     used to fluently chain operations.
        /// </returns>
        public DataContextBuilder WithModerator(string id, string username)
            {
            CreateUserInRoles(id, username, new[] {"Moderator"});
            return this;
            }

        void CreateUserInRoles(string id, string username, IEnumerable<string> roles)
            {
            var user = new ApplicationUser {Id = id, UserName = username, Email = $"{id}@nowhere.nw", EmailConfirmed = true};
            foreach (var role in roles)
                {
                var identityRole = GetOrCreateIdentityRole(role);
                var identityUserRole = new IdentityUserRole {RoleId = identityRole.Id, UserId = id};
                user.Roles.Add(identityUserRole);
                data.Table<IdentityUserRole>("AspNetUserRoles")
                    .Add(identityUserRole);
                }
            data.Table<ApplicationUser>("AspNetUsers").Add(user);
            }

        IdentityRole GetOrCreateIdentityRole(string roleName)
            {
            var existingRole = data.Table<IdentityRole>("AspNetRoles").SingleOrDefault(p => p.Name == roleName);
            if (existingRole != null)
                return existingRole;
            var identityRole = new IdentityRole(roleName);
            data.Table<IdentityRole>("AspNetRoles").Add(identityRole);
            return identityRole;
            }

        /// <summary>
        ///     Adds a standard user to the identity store.
        /// </summary>
        /// <param name="id">The user's unique identifier.</param>
        /// <param name="username">The user's login name.</param>
        /// <returns>
        ///     A reference to this <see cref="ControllerContextBuilder{TController}" /> that may be used to fluently
        ///     chain operations.
        /// </returns>
        public DataContextBuilder WithStandardUser(string id, string username)
            {
            CreateUserInRoles(id, username, new string[] { });
            return this;
            }

        /// <summary>
        ///     Adds an entity to the test data context, inferring the table name from the entity type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity, which determines to which table it is added.</typeparam>
        /// <param name="entity">
        ///     The initialized entity, including any foreign key IDs (navigation properties should not
        ///     be populated).
        /// </param>
        /// <returns>
        ///     A reference to this <see cref="ControllerContextBuilder{TController}" /> that may be used to
        ///     fluently chain operations.
        /// </returns>
        public DataContextBuilder WithEntity<TEntity>(TEntity entity) where TEntity : class
            {
            data.Table<TEntity>().Add(entity);
            return this;
            }

        /// <summary>
        ///     Adds an entity to the test data context and explicitly specifies the table name.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity, which determines to which table it is added.</typeparam>
        /// <param name="entity">
        ///     The initialized entity, including any foreign key IDs (navigation properties should not
        ///     be populated).
        /// </param>
        /// <param name="tableName">Specifies the table name if it cannot be inferred from the entity type name.</param>
        /// <returns>
        ///     A reference to this <see cref="ControllerContextBuilder{TController}" /> that may be used to
        ///     fluently chain operations.
        /// </returns>
        public DataContextBuilder WithEntity<TEntity>(TEntity entity, string tableName) where TEntity : class
            {
            data.Table<TEntity>(tableName).Add(entity);
            return this;
            }

        public DataContextBuilder WithUserAwardedBadges(string userId, string userName, params int[] badges)
            {
            var user = new ApplicationUser
                    {Id = userId, UserName = userName, Email = $"{userId}@nowhere.nw", EmailConfirmed = true};
            foreach (var badgeId in badges)
                {
                var badgeToAdd = new Badge
                    {
                    Id = badgeId,
                    Name = $"Badge-{badgeId}",
                    ImageIdentifier = $"Badge-{badgeId}"
                    };
                user.Badges.Add(badgeToAdd);
                badgeToAdd.Users.Add(user);
                data.Table<Badge>().Add(badgeToAdd);
                data.Table<ApplicationUserBadge>()
                    .Add(new ApplicationUserBadge {ApplicationUser_Id = user.Id, Badge_Id = badgeId});
                }
            data.Table<ApplicationUser>("AspNetUsers").Add(user);
            return this;
            }

        public IUnitOfWork Build()
            {
            var dataLoader = new ObjectDataLoader(data);
            UnitOfWork = uowBuilder.WithData(dataLoader).Build();
            return UnitOfWork;
            }

        public DataContextBuilder WithQueuedWorkItem(QueuedWorkItem item)
            {
            data.Table<QueuedWorkItem>().Add(item);
            return this;
            }
        }
    }