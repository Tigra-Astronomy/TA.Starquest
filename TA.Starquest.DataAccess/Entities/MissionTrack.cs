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
// File: MissionTrack.cs  Last modified: 2020-08-09@21:31 by Tim Long

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.Starquest.DataAccess.Entities
    {
    public class MissionTrack : IDomainEntity<int>
        {
        [Required]
        [Display(Name = "Track Name")]
        public string Name { get; set; }

        /// <summary>Track number determines the order in which tracks are displayed.</summary>
        /// <value>The number.</value>
        [Display(Name = "Track Number")]
        public int Number { get; set; }

        public virtual List<Challenge> Challenges { get; set; }

        [Required]
        [Display(Name = "Award Title")]
        public string AwardTitle { get; set; }

        [ForeignKey("BadgeId")]
        public virtual Badge Badge { get; set; }

        [Display(Name = "Badge ID")]
        public virtual int BadgeId { get; set; }

        [Display(Name = "Level ID")]
        public virtual int MissionLevelId { get; set; }

        public virtual MissionLevel MissionLevel { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        }
    }