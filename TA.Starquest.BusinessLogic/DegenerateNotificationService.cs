// This file is part of the TA.Starquest project
// Copyright © 2015-2024 Timtek Systems Limited, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: DegenerateNotificationService.cs  Last modified: 2024-2-26@20:17 by Tim

using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.DataAccess.Models;

namespace TA.Starquest.BusinessLogic;

public class DegenerateNotificationService : IGameNotificationService
{
    #region Implementation of IGameNotificationService

    /// <inheritdoc />
    public Task ObservationApproved(Observation observation) => Task.CompletedTask;

    /// <inheritdoc />
    public Task BadgeAwarded(Badge badge, ApplicationUser user, MissionTrack track) => Task.CompletedTask;

    /// <inheritdoc />
    public Task PendingObservationSummary(ApplicationUser user, IEnumerable<ModerationQueueItem> observations) =>
        Task.CompletedTask;

    #endregion
}