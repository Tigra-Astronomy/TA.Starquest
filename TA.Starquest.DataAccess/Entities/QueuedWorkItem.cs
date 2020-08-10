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
// File: QueuedWorkItem.cs  Last modified: 2020-08-09@21:31 by Tim Long

using System;
using System.ComponentModel.DataAnnotations;
using TA.Starquest.Core.QueueProcessing;

namespace TA.Starquest.DataAccess.Entities
    {
    /// <summary>Base class for queued work items</summary>
    public abstract class QueuedWorkItem : IDomainEntity<int>
        {
        /// <summary>The earliest moment in time at which the queued item is valid for processing.</summary>
        //Todo - EF Core dos not support index creation via data annotations [Index(IsUnique = false)]
        public DateTime ProcessAfter { get; set; }

        /// <summary>The name of the queue associated with the work item</summary>
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