// This file is part of the MS.Gamification project
// 
// File: ObservingSession.cs  Created: 2017-05-16@19:02
// Last modified: 2017-05-31@11:33

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TA.Starquest.Core.EventManagement;

namespace TA.Starquest.DataAccess.Entities
    {
    /// <summary>
    ///     Represents a planned observing session where observations
    ///     will be automatically awarded to attendees.
    /// </summary>
    /// <seealso cref="IDomainEntity{TKey}" />
    public class ObservingSession : IDomainEntity<int>
        {
        public ObservingSession()
            {
            Attendees = new List<StarquestUser>();
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
        public List<StarquestUser> Attendees { get; set; }

        public ScheduleState ScheduleState { get; set; }

        public bool RemindOneWeekBefore { get; set; }

        public bool RemindOneDayBefore { get; set; }

        public int Id { get; set; }
        }
    }