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
// File: StarquestLoggingProvider.cs  Last modified: 2020-08-30@19:18 by Tim Long

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.Extensions.Logging;
using TA.Utils.Core.Diagnostics;
using TA.Utils.Logging.NLog;

namespace TA.Starquest.Core.Logging
    {
    public class StarquestLoggingProvider : ILoggerProvider
        {
        /// <inheritdoc />
        public void Dispose() { }

        /// <inheritdoc />
        public ILogger CreateLogger(string categoryName)
            {
            return new StarquestLogger(categoryName);
            }
        }
    }

public class StarquestLogger : ILogger
    {
    private readonly string category;
    private readonly LoggingService logger;
    private int scopeId = 0;
    private List<DisposableScopeObject> scopes = new List<DisposableScopeObject>();

    public StarquestLogger(string category)
        {
        this.category = category;
        logger = new LoggingService();
        }

    /// <inheritdoc />
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
        Func<TState, Exception, string> formatter)
        {
        IFluentLogBuilder builder;
        switch (logLevel)
            {
                case LogLevel.Trace:
                    builder = logger.Trace(category);
                    break;
                case LogLevel.Debug:
                    builder = logger.Debug(category);
                    break;
                case LogLevel.Information:
                case LogLevel.None:
                default:
                    builder = logger.Info(category);
                    break;
                case LogLevel.Warning:
                    builder = logger.Warn(category);
                    break;
                case LogLevel.Error:
                    builder = logger.Error(category);
                    break;
                case LogLevel.Critical:
                    builder = logger.Error(category);
                    break;
            }

        var scopeProperties = scopes
            .ToDictionary(dso => dso.PropertyName, dso => dso.State);
        builder.Message(formatter(state, exception))
            .Exception(exception)
            .Property(typeof(TState).Name, state)
            .Property("EventId", eventId)
            .Properties(scopeProperties)
            .Write();
        }

    /// <inheritdoc />
    public bool IsEnabled(LogLevel logLevel)
        {
        return true;
        }

    /// <inheritdoc />
    public IDisposable BeginScope<TState>(TState state)
        {
        var id = Interlocked.Increment(ref scopeId);
        var scopeObject = new DisposableScopeObject(id, state, EndScope);
        return null;
        }

    private void EndScope(DisposableScopeObject scope) => scopes.Remove(scope);
    }

class DisposableScopeObject : IDisposable
    {
    public int Id { get; }
    private readonly Action<DisposableScopeObject> endScopeAction;
    public object State { get; }
    public string PropertyName => $"Scope-{State.GetType().Name}";
    
    public DisposableScopeObject(int scopeId, object state, Action<DisposableScopeObject> endScopeAction)
        {
        Id = scopeId;
        State = state;
        this.endScopeAction = endScopeAction;
        }

    /// <inheritdoc />
    public void Dispose()
        {
        endScopeAction(this);
        }
    }