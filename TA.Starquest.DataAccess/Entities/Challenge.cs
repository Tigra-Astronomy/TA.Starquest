// This file is part of the MS.Gamification project
// 
// File: Challenge.cs  Created: 2016-05-10@22:28
// Last modified: 2016-07-22@13:23

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