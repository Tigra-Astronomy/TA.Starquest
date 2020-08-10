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
// File: Badge.cs  Last modified: 2020-08-09@21:30 by Tim Long

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.Starquest.DataAccess.Entities
    {
    public class Badge : IDomainEntity<int>
        {
        public Badge()
            {
            Users = new List<StarquestUser>();
            }

        /// <summary>
        ///     Identifies the storage location of a badge bitmap to an <see cref="IImageStore" />
        ///     service.
        /// </summary>
        /// <value>The file identifier.</value>
        [Display(Name = "Image Identifier")]
        public string ImageIdentifier { get; set; }

        /// <summary>The display name of the badge.</summary>
        /// <value>The badge name.</value>
        [Display(Name = "Badge Name")]
        public string Name { get; set; }

        #region Navigation
        /// <summary>The list of users who have been awarded this badge.</summary>
        /// <value>The users.</value>
        public virtual List<StarquestUser> Users { get; set; }
        #endregion Navigation

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        }
    }