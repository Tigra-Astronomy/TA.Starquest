// This file is part of the TA.Starquest project
// Copyright © 2015-2024 Timtek Systems Limited, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: BatchCreateObservationResult.cs  Last modified: 2024-2-25@19:16 by Tim

using System.Collections.Generic;

namespace TA.Starquest.BusinessLogic.Models;

/// <summary>
///     Results from batch-creating observations.
/// </summary>
public record BatchCreateObservationsResult
{
    /// <summary>
    ///     The total number of observations that were created successfully.
    /// </summary>
    /// <value>The succeeded.</value>
    public int Succeeded { get; set; }

    /// <summary>
    ///     The total number of observations that were not created.
    /// </summary>
    /// <value>The failed.</value>
    public int Failed { get; set; }

    /// <summary>
    ///     The error that occurred for each user.
    /// </summary>
    /// <value>The errors.</value>
    public Dictionary<string, string> Errors { get; set; }

    public void Deconstruct(out int Succeeded, out int Failed, out Dictionary<string, string> Errors)
    {
        Succeeded = this.Succeeded;
        Failed = this.Failed;
        Errors = this.Errors;
    }
}
