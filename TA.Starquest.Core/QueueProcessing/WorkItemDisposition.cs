// This file is part of the MS.Gamification project
// 
// File: WorkItemDisposition.cs  Created: 2017-05-19@00:27
// Last modified: 2017-05-19@01:31

namespace TA.Starquest.Core.QueueProcessing
    {
    /// <summary>
    ///     The status of work items in the queue
    /// </summary>
    public enum WorkItemDisposition
        {
        /// <summary>
        ///     Indicates that a work item is in a queue awaiting its scheduled run time.
        /// </summary>
        Pending,
        /// <summary>
        ///     Indicates that the item is being dispatched to a work item procesor.
        /// </summary>
        InProgress,
        /// <summary>
        ///     Indicates that the work item was dispatched successfully
        /// </summary>
        Completed,
        /// <summary>
        ///     Indicates that the work item could not be dispatched
        /// </summary>
        NotRun,
        /// <summary>
        ///     Indicates that an unrecoverable error occurred when the work item was dispatched.
        /// </summary>
        Failed
        }
    }