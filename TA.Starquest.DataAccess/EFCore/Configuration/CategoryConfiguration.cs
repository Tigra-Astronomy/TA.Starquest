using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.EFCore.Configuration
    {
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
        {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<Category> builder)
            {
            builder.HasJsonSeedData("Categories.json");
            }
        }
    }