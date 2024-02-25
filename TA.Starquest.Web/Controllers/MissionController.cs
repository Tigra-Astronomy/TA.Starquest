using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TA.Starquest.BusinessLogic;
using TA.Starquest.DataAccess;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.DataAccess.Identity;
using TA.Starquest.DataAccess.QuerySpecifications;
using TA.Starquest.Web.ViewModels;

namespace TA.Starquest.Web.Controllers;

public class MissionController : Controller
{
    private readonly IUnitOfWork uow;
    private readonly ICurrentUser requestingUser;
    private readonly IMapper mapper;
    private readonly IGameEngineService gameEngine;

    public MissionController(
        IUnitOfWork        uow,
        ICurrentUser       requestingUser,
        IMapper            mapper,
        IGameEngineService gameEngine)
    {
        this.uow = uow;
        this.requestingUser = requestingUser;
        this.mapper = mapper;
        this.gameEngine = gameEngine;
    }

    public IActionResult Progress(int id) => throw new NotImplementedException();

    public IActionResult Index()
    {
        var specification = new SingleUserWithProfileInformation(requestingUser.UniqueId);
        var maybeUser = uow.Users.GetMaybe(specification);
        if (maybeUser.IsEmpty)
            return NotFound("User not found in the database");
        var appUser = maybeUser.Single();
        var missionSpec = new MissionProgressSummary();
        var missions = uow.Missions.AllSatisfying(missionSpec);
        var missionViewModel = missions.Select(p => mapper.Map<Mission, MissionProgressViewModel>(p)).ToList();
        var model = new UserProfileViewModel
        {
            UserId = requestingUser.UniqueId,
            UserName = requestingUser.DisplayName,
            EmailAddress = requestingUser.LoginName,
            Titles = Enumerable.Empty<string>(), //ToDo: coming soon...
            Missions = missionViewModel
        };

        var allChallenges = uow.Challenges.GetAll();
        foreach (var mission in model.Missions)
        foreach (var level in mission.Levels)
        {
            var challengesForLevel = allChallenges.Where(p => p.MissionTrack.MissionLevelId == level.Id);
            var observationSpec = new EligibleObservationsForChallenges(challengesForLevel, requestingUser.UniqueId);
            var eligibleObservations = uow.Observations.AllSatisfying(observationSpec);
            level.OverallProgressPercent = gameEngine.ComputePercentComplete(challengesForLevel, eligibleObservations);
        }

        return View(model);
    }
}