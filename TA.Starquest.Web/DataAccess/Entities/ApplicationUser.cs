// This file is part of the MS.Gamification project
// 
// File: ApplicationUser.cs  Created: 2016-05-10@22:28
// Last modified: 2016-07-20@13:29

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using MS.Gamification.Models;

namespace TA.Starquest.Web.DataAccess.Entities
    {
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser, IDomainEntity<string>
        {
        /// <summary>
        ///     The date and time on which the user account was provisioned.
        /// </summary>
        public DateTime Provisioned { get; set; } = DateTime.Now;

        #region Navigation
        public virtual List<Observation> Observations { get; set; } = new List<Observation>();

        public virtual List<Badge> Badges { get; set; } = new List<Badge>();
        #endregion Navigation
        }
    }