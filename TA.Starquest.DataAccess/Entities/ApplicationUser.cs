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
// File: StarquestUser.cs  Last modified: 2020-08-09@21:31 by Tim Long

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TA.Starquest.DataAccess.Entities
    {
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser, IDomainEntity<string>
        {
        /// <summary>The date and time on which the user account was provisioned.</summary>
        public DateTime Provisioned { get; set; } = DateTime.Now;

        #region Navigation
        public virtual ICollection<Observation> Observations { get; set; } = new List<Observation>();
        public virtual ICollection<UserBadge> UserBadges { get; set; } = new List<UserBadge>();
        #endregion Navigation

        #region Identity Navigation
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
        public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }
        #endregion
    }
}