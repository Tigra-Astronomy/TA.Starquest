// This file is part of the MS.Gamification project
// 
// File: EffortUnitOfWorkBuilder.cs  Created: 2016-11-01@19:37
// Last modified: 2016-12-30@04:22

using System.Data.Common;
using Effort;
using Effort.DataLoaders;
using Effort.Extra;
using MS.Gamification.DataAccess;
using MS.Gamification.DataAccess.EntityFramework6;

namespace MS.Gamification.Tests.TestHelpers
    {
    /// <summary>
    ///     Builds an <see cref="IUnitOfWork" /> based on the EFFORT in-memory database provider.
    /// </summary>
    class EffortUnitOfWorkBuilder
        {
        IDataLoader loader;

        public ApplicationDbContext DataContext { get; private set; }

        public DbConnection DataConnection { get; private set; }

        public EffortUnitOfWorkBuilder WithData(IDataLoader loader)
            {
            this.loader = loader;
            return this;
            }

        public IUnitOfWork Build()
            {
            var dataLoader = loader ?? new ObjectDataLoader(new ObjectData());
            DataConnection = DbConnectionFactory.CreateTransient(dataLoader);
            DataContext = new ApplicationDbContext(DataConnection);
            var uow = new EntityFramework6UnitOfWork(DataContext);
            return uow;
            }
        }
    }