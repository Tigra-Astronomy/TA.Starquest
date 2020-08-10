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
// File: Challenge.cs  Last modified: 2020-08-09@21:30 by Tim Long

using System.ComponentModel.DataAnnotations;

namespace TA.Starquest.DataAccess.Entities
    {
    public class Challenge : IDomainEntity<int>
        {
        internal const string NoImagePlaceholder = "NoImage";
        private string validationImage = NoImagePlaceholder;

        [Required]
        //ToDo [ImageIdentifier]
        [MaxLength(255)]
        [Display(Name = "Validation Image")]
        public string ValidationImage
            {
            get { return validationImage; }
            set { validationImage = string.IsNullOrWhiteSpace(value) ? NoImagePlaceholder : value; }
            }

        [Required]
        public string Name { get; set; }

        [Range(1, int.MaxValue)]
        public int Points { get; set; }

        public string Location { get; set; }

        public string BookSection { get; set; }

        public int Id { get; set; }

        #region Navigation properties
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int MissionTrackId { get; set; }

        public virtual MissionTrack MissionTrack { get; set; }
        #endregion Navigation properties
        }
    }