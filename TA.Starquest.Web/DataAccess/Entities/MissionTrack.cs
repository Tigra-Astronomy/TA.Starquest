// This file is part of the MS.Gamification project
// 
// File: MissionTrack.cs  Created: 2016-05-10@22:28
// Last modified: 2016-08-18@01:33

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TA.Starquest.Web.DataAccess;

namespace MS.Gamification.Models
    {
    public class MissionTrack : IDomainEntity<int>
        {
        [Required]
        [Display(Name = "Track Name")]
        public string Name { get; set; }

        /// <summary>
        ///     Track number determines the order in which tracks are displayed.
        /// </summary>
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