// This file is part of the MS.Gamification project
// 
// File: BuilderExtensions.cs  Created: 2016-11-01@19:37
// Last modified: 2016-12-12@23:25

using System.Web.Mvc;

namespace MS.Gamification.Tests.TestHelpers
    {
    static class BuilderExtensions
        {
        public static MissionBuilder WithMissionLevel(this DataContextBuilder builder, int missionId = 1)
            {
            return new MissionBuilder(builder, missionId);
            }

        public static ObservationBuilder WithObservation(this DataContextBuilder dcb)
            {
            return new ObservationBuilder(dcb);
            }

        public static ControllerContextBuilder<TController> WithTempData<TController>(this DataContextBuilder dcb, string key,
            object value)
            where TController : ControllerBase
            {
            var controllerContextBuilder = dcb as ControllerContextBuilder<TController>;
            return controllerContextBuilder.WithTempData(key, value);
            }
        }
    }