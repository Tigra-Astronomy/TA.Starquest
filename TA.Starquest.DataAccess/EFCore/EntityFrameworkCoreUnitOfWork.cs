// This file is part of the TA.Starquest project
// 
// Copyright © 2015-2020 Tigra Astronomy, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: EntityFrameworkCoreUnitOfWork.cs  Last modified: 2020-08-09@21:30 by Tim Long

using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using TA.Starquest.DataAccess.Entities;
using TA.Utils.Core.Diagnostics;

namespace TA.Starquest.DataAccess.EFCore;

/// <summary>
///     Implements the unit-of-work pattern using Entity Framework Core.
///     In EF Core, the <see cref="StarquestDbContext" /> class is essentially the Unit of Work,
///     so most processing is delegated to it. However, we expose a more sophisticated repository implementation.
/// </summary>
public class EntityFrameworkCoreUnitOfWork : IUnitOfWork
{
    private readonly StarquestDbContext dbContext;
    private readonly ILog log;

    public EntityFrameworkCoreUnitOfWork(StarquestDbContext context, ILog log)
    {
        dbContext = context;
        this.log = log;
        QueuedWorkItems = new QueuedWorkItemRepository(dbContext);
        Users = new UserRepository(dbContext);
        Challenges = new ChallengeRepository(dbContext);
        CategoriesRepository = new CategoryRepository(dbContext);
        Observations = new ObservationRepository(dbContext);
        MissionLevels = new MissionLevelRepository(dbContext);
        Missions = new MissionRepository(dbContext);
        MissionTracks = new MissionTrackRepository(dbContext);
        Badges = new BadgeRepository(dbContext);
        ObservingSessions = new ObservingSessionRepository(dbContext);
    }

    [NotNull] public IRepository<ObservingSession, int> ObservingSessions { get; }

    [NotNull] public IRepository<QueuedWorkItem, int> QueuedWorkItems { get; }

    [NotNull] public IRepository<Challenge, int> Challenges { get; }

    [NotNull] public IRepository<ApplicationUser, string> Users { get; }

    [NotNull] public IRepository<Category, int> CategoriesRepository { get; }

    [NotNull] public IRepository<Observation, int> Observations { get; }

    [NotNull] public IRepository<MissionLevel, int> MissionLevels { get; }

    [NotNull] public IRepository<Mission, int> Missions { get; }

    [NotNull] public IRepository<MissionTrack, int> MissionTracks { get; }

    [NotNull] public IRepository<Badge, int> Badges { get; }

    public void Commit()
    {
        try
        {
            dbContext.SaveChanges();
        }
        catch (Exception e)
        {
            log.Error()
                .Exception(e)
                .Message("Exception committing database transaction: {message}", e.Message)
                .Write();
            throw;
        }
    }

    public Task CommitAsync()
    {
        Contract.Ensures(Contract.Result<Task>() != null);
        try
        {
            return dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            log.Error()
                .Exception(e)
                .Message("Exception committing database transaction: {message}", e.Message)
                .Write();
            throw;
        }
    }

    public void Cancel()
    {
        log.Warn()
            .Message("Cancelling database transaction")
            .Property(nameof(dbContext), dbContext)
            .Write();
        dbContext.Dispose();
    }

    #region IDisposable Pattern

    // The IDisposable pattern, as described at
    // http://www.codeproject.com/Articles/15360/Implementing-IDisposable-and-the-Dispose-Pattern-P

    /// <summary>Finalizes this instance (called prior to garbage collection by the CLR)</summary>
    ~EntityFrameworkCoreUnitOfWork()
    {
        Dispose(false);
    }

    /// <summary>Disposes the unit of work, discarding any uncommitted repository modifications.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private bool disposed;

    /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
    /// <param name="fromUserCode">
    ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
    ///     unmanaged resources.
    /// </param>
    protected virtual void Dispose(bool fromUserCode)
    {
        if (!disposed)
            if (fromUserCode)
                // ToDo - Dispose managed resources (call Dispose() on any owned objects).
                // Do not dispose of any objects that may be referenced elsewhere.
                dbContext.Dispose();
        // ToDo - Release unmanaged resources here, if necessary.
        disposed = true;
    }

    #endregion
}