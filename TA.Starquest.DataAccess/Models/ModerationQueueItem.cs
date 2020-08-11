// This file is part of the MS.Gamification project
// 
// File: ModerationQueueViewModel.cs  Created: 2016-05-21@18:56
// Last modified: 2016-05-21@19:03

using System;

namespace TA.Starquest.DataAccess.Models
    {
    /// <summary>
    ///     Data transfer object used to display the moderation queue
    /// </summary>
    public class ModerationQueueItem
        {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string UserName { get; set; }

        public string ChallengeName { get; set; }
        }
    }