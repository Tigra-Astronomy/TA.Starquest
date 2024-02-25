// This file is part of the TA.Starquest project
// Copyright © 2015-2024 Timtek Systems Limited, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: IGameNotificationService.cs  Last modified: 2024-2-25@18:54 by Tim

using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.DataAccess.Models;

namespace TA.Starquest.BusinessLogic;

/// <summary>
///     A service that can notify users about certain game-related events.
///     Note that the notification service is only responsible for rendering the requested notification
///     on demand and it will not carry out any validation of game logic.
/// </summary>
public interface IGameNotificationService
{
    /// <summary>
    ///     Notifies the user that an observation they submitted has been approved by a moderator.
    /// </summary>
    /// <param name="observation">The observation that has been approved.</param>
    /// <returns>An awaitable Task.</returns>
    Task ObservationApproved(Observation observation);

    Task BadgeAwarded(Badge badge, ApplicationUser user, MissionTrack track);

    /// <summary>
    ///     Notifies a user about pending observations.
    /// </summary>
    /// <param name="user">The user to be notified.</param>
    /// <param name="observations">The list of pending observations.</param>
    /// <returns>Task.</returns>
    Task PendingObservationSummary(ApplicationUser user, IEnumerable<ModerationQueueItem> observations);
}
