using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TA.Starquest.DataAccess.Identity;

namespace TA.Starquest.DataAccess.EFCore.Configuration
    {
    class IdentityUserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
        {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
            {
            builder.HasData(new IdentityUserRole<string>
                    {RoleId = IdentityNames.AdministratorRoleId, UserId = IdentityNames.AdministratorUserId});
            }
        }
    }