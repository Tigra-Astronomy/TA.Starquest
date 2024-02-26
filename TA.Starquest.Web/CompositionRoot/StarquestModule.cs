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
using Ninject.Activation;
using Ninject.Modules;
using TA.Utils.Core.Diagnostics;
using TA.Utils.Logging.NLog;

namespace TA.Starquest.Web.CompositionRoot;

internal class StarquestModule : NinjectModule
{
    /// <inheritdoc />
    public override void Load()
    {
        Bind<ILog>().ToMethod(BuildLogger).InTransientScope();
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