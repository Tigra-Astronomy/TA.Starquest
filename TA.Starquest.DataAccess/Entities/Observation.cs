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
// File: Observation.cs  Last modified: 2020-08-09@21:31 by Tim Long

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TA.Starquest.DataAccess.Validation;

namespace TA.Starquest.DataAccess.Entities
    {
    public class Observation : IDomainEntity<int>
        {
        public virtual Challenge Challenge { get; set; }

        [Display(Name = "Date and Time")]
        public DateTime ObservationDateTimeUtc { get; set; }

        [Display(Name = "Equipment")]
        public ObservingEquipment Equipment { get; set; }

        [Display(Name = "Observing Site")]
        public string ObservingSite { get; set; }

        public AntoniadiScale Seeing { get; set; }

        public TransparencyLevel Transparency { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [ImageIdentifier]
        public string ExpectedImage { get; set; }

        [ImageIdentifier]
        public string SubmittedImage { get; set; }

        public ModerationState Status { get; set; }

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        #region Related Entities
        public virtual StarquestUser User { get; set; }

        [Required]
        public virtual string UserId { get; set; }

        public virtual int ChallengeId { get; set; }
        #endregion RelatedEntities
        }
    }