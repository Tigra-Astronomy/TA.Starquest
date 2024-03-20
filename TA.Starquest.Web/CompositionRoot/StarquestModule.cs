// This file is part of the TA.Starquest project
// Copyright © 2015-2024 Timtek Systems Limited, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: StarquestModule.cs  Last modified: 2024-2-25@23:54 by Tim

using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Ninject.Activation;
using Ninject.Modules;
using Ninject.Web.Common;
using TA.Starquest.BusinessLogic;
using TA.Starquest.DataAccess;
using TA.Starquest.DataAccess.EFCore;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.DataAccess.Identity;
using TA.Starquest.Web.Services;
using TA.Starquest.Web.ViewModels;
using TA.Utils.Core.Diagnostics;
using TA.Utils.Logging.NLog;

namespace TA.Starquest.Web.CompositionRoot;

internal class StarquestModule : NinjectModule
{
    /// <inheritdoc />
    public override void Load()
    {
        Bind<ILog>().ToMethod(BuildLogger).InTransientScope();
        Bind<IUnitOfWork>().To<EntityFrameworkCoreUnitOfWork>().InTransientScope();
        Bind<ICurrentUser>().ToMethod(GetCurrentWebUser).InRequestScope();
        var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<ViewModelMappingProfile>(); });
        Bind<IMapper>().ToMethod(m => mapperConfiguration.CreateMapper()).InSingletonScope();
        Bind<IGameEngineService>().To<GameRulesService>().InTransientScope();
        Bind<IGameNotificationService>().To<DegenerateNotificationService>().InTransientScope();
    }

    private AspNetIdentityCurrentUser GetCurrentWebUser(IContext arg)
    {
        var webContext = new HttpContextAccessor();
        return new AspNetIdentityCurrentUser(webContext);
    }

    /// <summary>
    ///     Build an instance of the logging service.
    ///     Attempt to set the logger name to the name of the requesting type.
    ///     Ninject sometimes provides this in <c>IContext.Request.Target.Member.DeclaringType</c>.
    ///     Other times this property will be null, so we will fall back to looking for a binding parameter
    ///     named "LogServiceName".
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    private static ILog BuildLogger(IContext context)
    {
        var sourceName = GetLogSourceName(context);
        var loggingService = new LoggingService(LogServiceOptions.DefaultOptions)
            .WithName(sourceName)
            .WithAmbientProperty("correlationId", Root.CorrelationId)
            .WithAmbientProperty("logger",        sourceName);
        return loggingService;
    }

    /// <summary>
    ///     Try to get the name of the requesting type, to be used as the logger name.
    /// </summary>
    /// <param name="context"></param>
    /// <returns>A source name for the requested log service instance.</returns>
    private static string GetLogSourceName(IContext context)
    {
        const string LogSourceParameterName = "LogSourceName";

        // If there is a binding parameter containing the caller name, then we should use that because it is most likely a user override.
        if (context.Request.Parameters.Any(p => p.Name == LogSourceParameterName))
        {
            var param = context.Request.Parameters.First(p => p.Name == LogSourceParameterName);
            return (string)param.GetValue(context, null);
        }

        // If we are being injected into a type via the constructor, then Ninject should supply the target type.
        // We will use Ninject's injection target if possible.
        if (context.Request.Target != null)
        {
            var target = context.Request.Target; // Get information about the target of a dependency resolution request.
            var targetMember =
                target?.Member; // The member being injected - this is usually ".ctor" of the target type but could be a property.
            var targetType = targetMember?.ReflectedType; // The type into which the dependency is being injected.
            var targetTypeName = targetType?.Name ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(targetTypeName))
                return targetTypeName;
        }

        // Otherwise, there's not much we can do other than shrug and return a safe, sensible, non-blank default.
        return "root";
    }
}

public class ViewModelMappingProfile : Profile
{
    public ViewModelMappingProfile()
    {
        //CreateMap<CreateChallengeViewModel, Challenge>()
        //    .ForMember(m => m.Id, m => m.Ignore())
        //    .ForMember(m => m.Category, m => m.Ignore())
        //    .ForMember(m => m.MissionTrack, m => m.Ignore())
        //    .ReverseMap();
        //CreateMap<Observation, SubmitObservationViewModel>()
        //    .ForMember(m => m.ObservationDateTimeLocal, m => m.MapFrom(s => s.ObservationDateTimeUtc.ToLocalTime()))
        //    .ForMember(m => m.ValidationImages, m => m.Ignore())
        //    .ForMember(m => m.EquipmentPicker, m => m.Ignore())
        //    .ForMember(m => m.SeeingPicker, m => m.Ignore())
        //    .ForMember(m => m.TransparencyPicker, m => m.Ignore())
        //    .ReverseMap()
        //    .ForMember(m => m.ObservationDateTimeUtc, m => m.MapFrom(s => s.ObservationDateTimeLocal.ToUniversalTime()));
        //CreateMap<Observation, ObservationDetailsViewModel>()
        //    .ForMember(m => m.UserName, m => m.MapFrom(s => s.User.UserName));
        //CreateMap<Observation, ModerationQueueItem>()
        //    .ForMember(m => m.DateTime, m => m.MapFrom(s => s.ObservationDateTimeUtc))
        //    .ForMember(m => m.ObservationId, m => m.MapFrom(s => s.Id))
        //    .ForMember(m => m.UserName, m => m.MapFrom(s => s.User.UserName));
        //CreateMap<ApplicationUser, ManageUserViewModel>()
        //    .ForMember(m => m.Selected, m => m.UseValue(false))
        //    .ForMember(m => m.AccountLockedUntilUtc, m => m.MapFrom(s => s.LockoutEndDateUtc))
        //    //.ForMember(m => m.AccountLocked, m => m.MapFrom(s => s.LockoutEndDateUtc > DateTime.UtcNow))
        //    .ForMember(m => m.EmailVerified, m => m.MapFrom(s => s.EmailConfirmed))
        //    .ForMember(m => m.HasValidPassword, m => m.ResolveUsing(r => !string.IsNullOrWhiteSpace(r.PasswordHash)))
        //    .ForMember(m => m.Roles, m => m.Ignore())
        //    .ForMember(m => m.RoleToAdd, m => m.Ignore())
        //    .ForMember(m => m.RolePicker, m => m.Ignore())
        //    .IgnoreAllPropertiesWithAnInaccessibleSetter();
        //CreateMap<BatchObservationViewModel, Observation>()
        //    .ForMember(m => m.Challenge, m => m.Ignore())
        //    .ForMember(m => m.ExpectedImage, m => m.Ignore())
        //    .ForMember(m => m.Status, m => m.Ignore())
        //    .ForMember(m => m.Id, m => m.Ignore())
        //    .ForMember(m => m.User, m => m.Ignore())
        //    .ForMember(m => m.UserId, m => m.Ignore());
        CreateMap<Challenge, ChallengeViewModel>()
            .ForMember(m => m.HasObservation, m => m.Ignore());
        CreateMap<MissionTrack, TrackProgressViewModel>()
            .ForMember(m => m.PercentComplete, m => m.Ignore());
        CreateMap<MissionLevel, LevelProgressViewModel>()
            .ForMember(m => m.Unlocked,               m => m.Ignore())
            .ForMember(m => m.OverallProgressPercent, m => m.Ignore());
        CreateMap<Mission, MissionProgressViewModel>()
            .ForMember(m => m.MissionTitle, m => m.MapFrom(s => s.Title))
            .ForMember(m => m.Levels,       m => m.MapFrom(s => s.MissionLevels));
        CreateMap<MissionTrackViewModel, MissionTrack>()
            .ForMember(m => m.Challenges,   m => m.Ignore())
            .ForMember(m => m.Id,           m => m.Ignore())
            .ForMember(m => m.Badge,        m => m.Ignore())
            .ForMember(m => m.MissionLevel, m => m.Ignore())
            .ReverseMap();
        //CreateMap<MissionLevelViewModel, MissionLevel>()
        //    .ForMember(m => m.Tracks, m => m.Ignore())
        //    .ForMember(m => m.Mission, m => m.Ignore())
        //    .ReverseMap();
    }
}
