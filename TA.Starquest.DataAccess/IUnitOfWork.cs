// This file is part of the MS.Gamification project
// 
// File: IUnitOfWork.cs  Created: 2016-11-01@19:37
// Last modified: 2017-05-18@22:12

using System;
using System.Threading.Tasks;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess
    {
    /// <summary>
    ///     Represents a database transaction
    /// </summary>
    public interface IUnitOfWork : IDisposable
        {
        /// <summary>
        ///     Gets the challenges repository.
        /// </summary>
        /// <value>The challenges repository.</value>
        IRepository<Challenge, int> Challenges { get; }

        /// <summary>
        ///     Gets the users repository.
        /// </summary>
        /// <value>The users.</value>
        IRepository<StarquestUser, string> Users { get; }

        /// <summary>
        ///     Gets the categories repository.
        /// </summary>
        /// <value>The categories repository.</value>
        IRepository<Category, int> CategoriesRepository { get; }

        /// <summary>
        ///     Gets the observations repository.
        /// </summary>
        /// <value>The observations repository.</value>
        IRepository<Observation, int> Observations { get; }

        /// <summary>
        ///     Gets the missions repository.
        /// </summary>
        /// <value>The missions queryable collection.</value>
        IRepository<MissionLevel, int> MissionLevels { get; }

        /// <summary>
        ///     Gets the missions.
        /// </summary>
        /// <value>The missions.</value>
        IRepository<Mission, int> Missions { get; }

        /// <summary>
        ///     Gets the mission tracks.
        /// </summary>
        /// <value>The mission tracks.</value>
        IRepository<MissionTrack, int> MissionTracks { get; }

        /// <summary>
        ///     All badges known to the system.
        /// </summary>
        /// <value>The badges.</value>
        IRepository<Badge, int> Badges { get; }

        /// <summary>
        ///     Scheduled observing sessions
        /// </summary>
        /// <value>The observing sessions.</value>
        IRepository<ObservingSession, int> ObservingSessions { get; }

        /// <summary>
        ///     Items of various types queued for later processing
        /// </summary>
        /// <value>The queued work items.</value>
        IRepository<QueuedWorkItem, int> QueuedWorkItems { get; }

        /// <summary>
        ///     Commits changes to the database and completes the transaction.
        /// </summary>
        void Commit();

        /// <summary>
        ///     Asynchronously commits changes to the database and completes the transaction.
        /// </summary>
        Task CommitAsync();

        /// <summary>
        ///     Cancels the transaction and undoes any pending changes.
        /// </summary>
        void Cancel();
        }
    }