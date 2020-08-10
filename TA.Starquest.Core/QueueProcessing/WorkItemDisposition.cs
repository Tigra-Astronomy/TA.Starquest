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
// File: WorkItemDisposition.cs  Last modified: 2020-08-09@21:29 by Tim Long

namespace TA.Starquest.Core.QueueProcessing
    {
    /// <summary>The status of work items in the queue</summary>
    public enum WorkItemDisposition
        {
        /// <summary>Indicates that a work item is in a queue awaiting its scheduled run time.</summary>
        Pending,
        /// <summary>Indicates that the item is being dispatched to a work item procesor.</summary>
        InProgress,
        /// <summary>Indicates that the work item was dispatched successfully</summary>
        Completed,
        /// <summary>Indicates that the work item could not be dispatched</summary>
        NotRun,
        /// <summary>Indicates that an unrecoverable error occurred when the work item was dispatched.</summary>
        Failed
        }
    }