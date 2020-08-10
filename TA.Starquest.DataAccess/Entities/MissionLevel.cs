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
// File: MissionLevel.cs  Last modified: 2020-08-09@21:31 by Tim Long

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using TA.Starquest.DataAccess.Validation;

namespace TA.Starquest.DataAccess.Entities
    {
    public class MissionLevel : IDomainEntity<int>
        {
        [Required]
        public string Name { get; set; }

        public int Level { get; set; }

        [Required]
        public string AwardTitle { get; set; }

        [DefaultValue("")]
        [NotNull]
        //ToDo [AllowHtml]
        [XmlDocument("LevelPreconditionSchema")]
        [DataType(DataType.MultilineText)]
        public string Precondition { get; set; } = string.Empty;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        #region Navigation
        public virtual List<MissionTrack> Tracks { get; set; }

        public int MissionId { get; set; }

        public virtual Mission Mission { get; set; }
        #endregion Navigation
        }
    }