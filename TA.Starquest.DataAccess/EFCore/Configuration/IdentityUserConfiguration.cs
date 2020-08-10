using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.DataAccess.Identity;

namespace TA.Starquest.DataAccess.EFCore.Configuration
    {
    class IdentityUserConfiguration : IEntityTypeConfiguration<StarquestUser>
        {
        private const string AdministratorUserName = "Administrator";
        private const string AdministratorTemporaryPassword = "starquest";
        private const string AdministratorEmail = "Tim@tigranetworks.co.uk";

        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<StarquestUser> builder)
            {
            var passwordHasher = new PasswordHasher<StarquestUser>();
            var adminUser = new StarquestUser
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