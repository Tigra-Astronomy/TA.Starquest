// This file is part of the MS.Gamification project
// 
// File: QueuedWorkItem.cs  Created: 2017-05-18@22:31
// Last modified: 2017-05-20@00:14

using System;
using System.ComponentModel.DataAnnotations;
using TA.Starquest.Core.QueueProcessing;

namespace TA.Starquest.DataAccess.Entities
    {
    /// <summary>
    ///     Base class for queued work items
    /// </summary>
    public abstract class QueuedWorkItem : IDomainEntity<int>
        {
        /// <summary>
        ///     The earliest moment in time at which the queued item is valid for processing.
        /// </summary>
        //Todo - EF Core dos not support index creation via data annotations [Index(IsUnique = false)]
        public DateTime ProcessAfter { get; set; }

        /// <summary>
        ///     The name of the queue associated with the work item
        /// </summary>
        /// <value>The name of the queue.</value>
        [Required]
        [MaxLength(8)]
        [MinLength(1)]
        [RegularExpression("[A-Za-z]+")]
        public string QueueName { get; set; }

        public WorkItemDisposition Disposition { get; set; }

        public int Id { get; set; }
        }
    }