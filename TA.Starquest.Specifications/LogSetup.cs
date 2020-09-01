// This file is part of the TA.NexDome.AscomServer project
// Copyright © 2019-2019 Tigra Astronomy, all rights reserved.

using Machine.Specifications;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Targets;
using TA.Starquest.Core.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;
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
                "${time}|${pad:padding=-5:inner=${uppercase:${level}}}|${pad:padding=-16:inner=${callsite:className=true:fileName=false:includeSourcePath=false:methodName=false:includeNamespace=false}}|${message}";
            unitTestRunnerTarget.RawWrite = true;
            configuration.AddRuleForAllLevels(unitTestRunnerTarget);
            LogManager.Configuration = configuration;
            LogFactory.CreateLogger("MSpec").LogDebug("Logging initialized");
            }

        public void OnAssemblyComplete() { }
        }
    }