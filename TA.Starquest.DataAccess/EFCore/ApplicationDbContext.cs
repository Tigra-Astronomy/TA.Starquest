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
// File: ApplicationDbContext.cs  Last modified: 2020-09-01@04:21 by Tim Long

using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.DataAccess.Entities.QueueWorkItems;

namespace TA.Starquest.DataAccess.EFCore
    {
    public class ApplicationDbContext : IdentityDbContext<StarquestUser>
        {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public virtual DbSet<Challenge> Challenges { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<MissionLevel> MissionLevels { get; set; }

        public virtual DbSet<MissionTrack> MissionTracks { get; set; }

        public virtual DbSet<Observation> Observations { get; set; }

        public virtual DbSet<Mission> Missions { get; set; }

        public virtual DbSet<Badge> Badges { get; set; }

        public virtual DbSet<ObservingSession> ObservingSessions { get; set; }

        public virtual DbSet<QueuedWorkItem> QueuedWorkItems { get; set; }

        public virtual DbSet<UserBadge> UserBadges { get; set; } // Many to Many navigation table

        protected override void OnModelCreating(ModelBuilder builder)
            {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Add implicit entities for Table-Per-Hierarchy mapping of QueuedWorkItem
            builder.Entity<ObservingSessionReminder>();
            builder.Entity<ObservingSessionCancellation>();

            // Seed roles

            // Seed admin user
            // Seed categories from JSON data file

            // Apply all configuration classes found in the current assembly.
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }
        }
    }