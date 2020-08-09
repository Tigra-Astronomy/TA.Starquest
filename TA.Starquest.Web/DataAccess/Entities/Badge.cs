// This file is part of the MS.Gamification project
// 
// File: Badge.cs  Created: 2016-07-21@12:10
// Last modified: 2016-07-26@13:35

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TA.Starquest.Web.DataAccess;
using TA.Starquest.Web.DataAccess.Entities;

namespace MS.Gamification.Models
    {
    public class Badge : IDomainEntity<int>
        {
        public Badge()
            {
            Users = new List<ApplicationUser>();
            }

        /// <summary>
        ///     Identifies the storage location of a badge bitmap to an <see cref="IImageStore" /> service.
        /// </summary>
        /// <value>The file identifier.</value>
        [Display(Name = "Image Identifier")]
        public string ImageIdentifier { get; set; }

        /// <summary>
        ///     The display name of the badge.
        /// </summary>
        /// <value>The badge name.</value>
        [Display(Name = "Badge Name")]
        public string Name { get; set; }

        #region Navigation
        /// <summary>
        ///     The list of users who have been awarded this badge.
        /// </summary>
        /// <value>The users.</value>
        public virtual List<ApplicationUser> Users { get; set; }
        #endregion Navigation

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        }
    }