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
// File: LogSetup.cs  Last modified: 2020-09-01@23:01 by Tim Long

using Machine.Specifications;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Targets;
using TA.Starquest.Core.Logging;
using LogLevel = NLog.LogLevel;

namespace TA.Starquest.Specifications
    {
    public class LogSetup : IAssemblyContext
        {
        public static ILoggerFactory LogFactory = LoggerFactory.Create(
            config => config.AddProvider(new StarquestLoggingProvider()));

        public void OnAssemblyStart()
            {
            var configuration = new LoggingConfiguration();
            var unitTestRunnerTarget = new TraceTarget();
            configuration.AddTarget("Unit test runner", unitTestRunnerTarget);
            unitTestRunnerTarget.Layout =
                "${time}|${pad:padding=-5:inner=${uppercase:${level}}}|${pad:padding=-16:inner=${logger}}|${message}";
            unitTestRunnerTarget.RawWrite = true;
            configuration.AddRuleForAllLevels(unitTestRunnerTarget);
            LogManager.Configuration = configuration;
            LogFactory.CreateLogger("MSpec").LogDebug("Logging initialized");
            }

        public void OnAssemblyComplete() { }

        internal static void MuteLogging() => SetLogLevel(LogLevel.Off);

        internal static void EnableLogging() => SetLogLevel(LogLevel.Debug);

        /// <summary>Reconfigures the NLog logging level.</summary>
        /// <param name="level">The <see cref="LogLevel" /> to be set.</param>
        private static void SetLogLevel(LogLevel level)
            {
            // Uncomment these to enable NLog logging. NLog exceptions are swallowed by default.
            ////NLog.Common.InternalLogger.LogFile = @"C:\Temp\nlog.debug.log";
            ////NLog.Common.InternalLogger.LogLevel = LogLevel.Debug;

            if (level == LogLevel.Off)
                {
                LogManager.DisableLogging();
                }
            else
                {
                if (!LogManager.IsLoggingEnabled())
                    {
                    LogManager.EnableLogging();
                    }

                foreach (var rule in LogManager.Configuration.LoggingRules)
                    {
                    // Iterate over all levels up to and including the target, (re)enabling them.
                    for (int i = level.Ordinal; i <= 5; i++)
                        {
                        rule.EnableLoggingForLevel(LogLevel.FromOrdinal(i));
                        }
                    }
                }

            LogManager.ReconfigExistingLoggers();
            }
        }
    }