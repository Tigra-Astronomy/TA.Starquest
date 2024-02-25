// This file is part of the TA.Starquest project
// Copyright © 2015-2024 Timtek Systems Limited, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: IGameEngineService.cs  Last modified: 2024-2-25@18:42 by Tim

using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Starquest.BusinessLogic.Models;
using TA.Starquest.BusinessLogic.Preconditions;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.BusinessLogic;

public interface IGameEngineService
{
    /// <summary>
    ///     Computes the percent complete for a set of challenges, given a set of eligible observations. The
    ///     computation is based on the number of points gained, rather than just a simple count.
    /// </summary>
    /// <param name="challenges">The set of challenges that represents 100% progress.</param>
    /// <param name="eligibleObservations">The eligible observations for the set of challenges.</param>
    /// <returns>The computed percentage, as an integer, guaranteed to be between 0% and 100% inclusive.</returns>
    /// <remarks>
    ///     It is assumed that the set of observations has already been filtered for eligibility, e.g. by calling
    ///     <see cref="EligibleObservationsForChallenges" />.
    /// </remarks>
    int ComputePercentComplete(IEnumerable<Challenge> challenges, IEnumerable<Observation> eligibleObservations);

    /// <summary>
    ///     Creates observations in bulk, for the specified list of users.
    /// </summary>
    /// <param name="observation">The observation template.</param>
    /// <param name="userIds">A list of user IDs.</param>
    BatchCreateObservationsResult BatchCreateObservations(Observation observation, IEnumerable<string> userIds);

    /// <summary>
    ///     Evaluates whether the user is entitled to any new badges, as a result of submitting an observation.
    /// </summary>
    /// <param name="observation">The observation that has just been approved for the user.</param>
    Task EvaluateBadges(Observation observation);

    /// <summary>
    ///     Determines whether a level is unlocked for a user by evaluating the level preconditions against that user.
    /// </summary>
    /// <param name="level">The level.</param>
    /// <param name="userId">The user.</param>
    /// <returns><c>true</c> if [is level unlocked for user] [the specified level]; otherwise, <c>false</c>.</returns>
    bool IsLevelUnlockedForUser(IPreconditionXml level, string userId);

    /// <summary>
    ///     Determines whether the supplied set of observations are sufficient to complete the given level.
    /// </summary>
    /// <param name="level">The level.</param>
    /// <param name="observations">The observations.</param>
    /// <returns><c>true</c> if [is level complete] [the specified level]; otherwise, <c>false</c>.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    bool IsLevelComplete(MissionLevel level, IEnumerable<Observation> observations);

    /// <summary>
    ///     Deletes the specified mission, if it is safe to do so.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Task.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the mission could not be deleted.</exception>
    Task DeleteMissionAsync(int id);

    /// <summary>
    ///     Deletes the specified mission level, if it is safe to do so.
    /// </summary>
    /// <param name="levelId">The ID of the level to be deleted.</param>
    /// <exception cref="InvalidOperationException">Thrown if the level could not be deleted.</exception>
    Task DeleteLevelAsync(int levelId);

    /// <summary>
    ///     Creates the specified level according to game rules.
    ///     Throws an exception if the level was invalid or could not be created.
    /// </summary>
    /// <param name="newLevel">The new level.</param>
    /// <exception cref="ArgumentException">Thrown if the level could not be created for any reason.</exception>
    Task CreateLevelAsync(MissionLevelModel newLevel);

    /// <summary>
    ///     Updates the level in the database with the supplied values, provided
    ///     that no game rules are violated.
    /// </summary>
    /// <param name="updatedLevel">The updated level (which must include the ID).</param>
    Task UpdateLevelAsync(MissionLevelModel updatedLevel);

    /// <summary>
    ///     Creates a new mission track, subject to game logic rules.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if the track is not created for any reason.</exception>
    /// <param name="newTrack">The new track.</param>
    Task CreateTrackAsync(MissionTrack newTrack);

    /// <summary>
    ///     Deletes the track provided game rules allow it.
    /// </summary>
    /// <param name="id">The track ID.</param>
    /// <exception cref="InvalidOperationException">Thrown if the track was not deleted for any reason.</exception>
    Task DeleteTrackAsync(int id);

    /// <summary>
    ///     Updates a mission track from values in the submitted model, provided that game rules allow it.
    /// </summary>
    /// <param name="model">The model containing new values.</param>
    /// <returns>Task.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the track was not updated for any reason.</exception>
    Task UpdateTrackAsync(MissionTrackModel model);
}