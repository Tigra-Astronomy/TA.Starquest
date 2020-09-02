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
// File: IdentityUserConfiguration.cs  Last modified: 2020-09-02@14:59 by Tim Long

using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.DataAccess.Identity;

namespace TA.Starquest.DataAccess.EFCore.Configuration
    {
    class IdentityUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
        {
        private const string AdministratorUserName = "Administrator";
        private const string AdministratorTemporaryPassword = "starquest";
        private const string AdministratorEmail = "Tim@tigranetworks.co.uk";

        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
            {
            // Seed the default administrator account
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser
                {
                Email = AdministratorEmail,
                NormalizedEmail = AdministratorEmail.ToUpper(),
                EmailConfirmed = true,
                Id = IdentityNames.AdministratorUserId,
                UserName = AdministratorUserName,
                NormalizedUserName = AdministratorUserName.ToUpper(),
                Provisioned = DateTime.UtcNow,
                LockoutEnabled = false
                };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, AdministratorTemporaryPassword);
            builder.HasData(adminUser);
            }
        }
    }