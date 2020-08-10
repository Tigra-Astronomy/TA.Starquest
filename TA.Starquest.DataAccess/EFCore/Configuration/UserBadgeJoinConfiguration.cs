﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess.EFCore.Configuration
{
    class UserBadgeJoinConfiguration : IEntityTypeConfiguration<UserBadge>
    {
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<UserBadge> builder)
        {
        builder.HasKey(entity => new {entity.UserId, entity.BadgeId});
        builder.HasIndex(e => e.Awarded);
        }
    }
}
