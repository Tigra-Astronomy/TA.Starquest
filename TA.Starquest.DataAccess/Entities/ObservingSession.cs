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
// File: ObservingSession.cs  Last modified: 2020-08-09@21:31 by Tim Long

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TA.Starquest.Core.EventManagement;

namespace TA.Starquest.DataAccess.Entities
    {
    /// <summary>
    ///     Represents a planned observing session where observations will be automatically awarded to
    ///     attendees.
    /// </summary>
    /// <seealso cref="IDomainEntity{TKey}" />
    public class ObservingSession : IDomainEntity<int>
        {
        public ObservingSession()
            {
            Attendees = new List<ApplicationUser>();
            Venue = string.Empty;
            Title = string.Empty;
            Description = string.Empty;
            StartsAt = DateTime.Now;
            }

        [Required]
        [NotNull]
        public string Title { get; set; }

        [Required]
        [NotNull]
        public string Venue { get; set; }

        public DateTime StartsAt { get; set; }

        public string Description { get; set; }

        [NotNull]
        public List<ApplicationUser> Attendees { get; set; }

        public ScheduleState ScheduleState { get; set; }

        public bool RemindOneWeekBefore { get; set; }

        public bool RemindOneDayBefore { get; set; }

        public int Id { get; set; }
        }
    }