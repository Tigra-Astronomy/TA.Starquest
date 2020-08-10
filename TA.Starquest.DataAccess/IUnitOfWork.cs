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
// File: IUnitOfWork.cs  Last modified: 2020-08-09@21:31 by Tim Long

using System;
using System.Threading.Tasks;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess
    {
    /// <summary>Represents a database transaction</summary>
    public interface IUnitOfWork : IDisposable
        {
        /// <summary>Gets the challenges repository.</summary>
        /// <value>The challenges repository.</value>
        IRepository<Challenge, int> Challenges { get; }

        /// <summary>Gets the users repository.</summary>
        /// <value>The users.</value>
        IRepository<StarquestUser, string> Users { get; }

        /// <summary>Gets the categories repository.</summary>
        /// <value>The categories repository.</value>
        IRepository<Category, int> CategoriesRepository { get; }

        /// <summary>Gets the observations repository.</summary>
        /// <value>The observations repository.</value>
        IRepository<Observation, int> Observations { get; }

        /// <summary>Gets the missions repository.</summary>
        /// <value>The missions queryable collection.</value>
        IRepository<MissionLevel, int> MissionLevels { get; }

        /// <summary>Gets the missions.</summary>
        /// <value>The missions.</value>
        IRepository<Mission, int> Missions { get; }

        /// <summary>Gets the mission tracks.</summary>
        /// <value>The mission tracks.</value>
        IRepository<MissionTrack, int> MissionTracks { get; }

        /// <summary>All badges known to the system.</summary>
        /// <value>The badges.</value>
        IRepository<Badge, int> Badges { get; }

        /// <summary>Scheduled observing sessions</summary>
        /// <value>The observing sessions.</value>
        IRepository<ObservingSession, int> ObservingSessions { get; }

        /// <summary>Items of various types queued for later processing</summary>
        /// <value>The queued work items.</value>
        IRepository<QueuedWorkItem, int> QueuedWorkItems { get; }

        /// <summary>Commits changes to the database and completes the transaction.</summary>
        void Commit();

        /// <summary>Asynchronously commits changes to the database and completes the transaction.</summary>
        Task CommitAsync();

        /// <summary>Cancels the transaction and undoes any pending changes.</summary>
        void Cancel();
        }
    }