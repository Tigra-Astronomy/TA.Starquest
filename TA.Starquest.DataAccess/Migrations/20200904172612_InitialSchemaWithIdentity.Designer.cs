﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TA.Starquest.DataAccess.EFCore;

namespace TA.Starquest.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200904172612_InitialSchemaWithIdentity")]
    partial class InitialSchemaWithIdentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "1204ca89-ad5a-4e52-af4d-cb9864254e91",
                            ConcurrencyStamp = "c818258e-7020-4bf4-b4e3-a29eeae65e55",
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = "341c4df2-23fe-4905-96f6-0914f73d95e1",
                            ConcurrencyStamp = "a16a3a21-f090-47c2-b856-39ef608c90a1",
                            Name = "Moderator"
                        },
                        new
                        {
                            Id = "27b31d46-7f3e-4bc9-a9cc-4718797c12d8",
                            ConcurrencyStamp = "aad046ed-1602-468a-98cf-ee33c64299a2",
                            Name = "EventManager"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "c2e1b3d3-f1cf-4c9b-b712-37502c6e9992",
                            RoleId = "1204ca89-ad5a-4e52-af4d-cb9864254e91"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<int?>("ObservingSessionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Provisioned")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("ObservingSessionId");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "c2e1b3d3-f1cf-4c9b-b712-37502c6e9992",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "95aacb49-849b-4746-8f71-8c8c913217fc",
                            Email = "Tim@tigranetworks.co.uk",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "TIM@TIGRANETWORKS.CO.UK",
                            NormalizedUserName = "ADMINISTRATOR",
                            PasswordHash = "AQAAAAEAACcQAAAAEGGR2g0T4XmZHvoOKx/EqCsSkmURdMKolFHkUILGmwa7V6SwnOouEcOjO0E4yHjjuA==",
                            PhoneNumberConfirmed = false,
                            Provisioned = new DateTime(2020, 9, 4, 17, 26, 11, 301, DateTimeKind.Utc).AddTicks(4581),
                            SecurityStamp = "b63212cc-9eed-4b0a-ba76-87d748cd85d2",
                            TwoFactorEnabled = false,
                            UserName = "Administrator"
                        });
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.Badge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageIdentifier")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Artificial Satellite"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Asterism"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Astrometry"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Comet"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Constellation"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Crater"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Dark Nebula"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Diffuse Nebula"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Double Star"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Eclipse"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Emission Nebula"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Galaxy"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Globular Cluster"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Mare"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Meteor"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Minor Planet"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Open Cluster"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Phase"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Phenomenon"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Planet"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Planetary Nebula"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Region"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Satellite"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Sky"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Star"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Surface Feature"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Variable Star"
                        });
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.Challenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BookSection")
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<int>("MissionTrackId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ValidationImage")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MissionTrackId");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Precondition")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.MissionLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AwardTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MissionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Precondition")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MissionId");

                    b.ToTable("MissionLevels");
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.MissionTrack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AwardTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("BadgeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MissionLevelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BadgeId");

                    b.HasIndex("MissionLevelId");

                    b.ToTable("MissionTracks");
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.Observation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChallengeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Equipment")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ExpectedImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ObservationDateTimeUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("ObservingSite")
                        .HasColumnType("TEXT");

                    b.Property<int>("Seeing")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubmittedImage")
                        .HasColumnType("TEXT");

                    b.Property<int>("Transparency")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.HasIndex("UserId");

                    b.ToTable("Observations");
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.ObservingSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("RemindOneDayBefore")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RemindOneWeekBefore")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ScheduleState")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartsAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ObservingSessions");
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.QueuedWorkItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Disposition")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ProcessAfter")
                        .HasColumnType("TEXT");

                    b.Property<string>("QueueName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.ToTable("QueuedWorkItems");

                    b.HasDiscriminator<string>("Discriminator").HasValue("QueuedWorkItem");
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.UserBadge", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("BadgeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Awarded")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "BadgeId");

                    b.HasIndex("Awarded");

                    b.HasIndex("BadgeId");

                    b.ToTable("UserBadges");
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.QueueWorkItems.ObservingSessionCancellation", b =>
                {
                    b.HasBaseType("TA.Starquest.DataAccess.Entities.QueuedWorkItem");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ObservingSessionId")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("ObservingSessionCancellation");
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.QueueWorkItems.ObservingSessionReminder", b =>
                {
                    b.HasBaseType("TA.Starquest.DataAccess.Entities.QueuedWorkItem");

                    b.Property<int?>("ObservingSessionId")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("ObservingSessionReminder");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TA.Starquest.DataAccess.Entities.ApplicationUser", null)
                        .WithMany("Claims")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("TA.Starquest.DataAccess.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TA.Starquest.DataAccess.Entities.ApplicationUser", null)
                        .WithMany("Logins")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("TA.Starquest.DataAccess.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("TA.Starquest.DataAccess.Entities.ApplicationUser", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TA.Starquest.DataAccess.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TA.Starquest.DataAccess.Entities.ApplicationUser", null)
                        .WithMany("Tokens")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("TA.Starquest.DataAccess.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.ApplicationUser", b =>
                {
                    b.HasOne("TA.Starquest.DataAccess.Entities.ObservingSession", null)
                        .WithMany("Attendees")
                        .HasForeignKey("ObservingSessionId");
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.Challenge", b =>
                {
                    b.HasOne("TA.Starquest.DataAccess.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TA.Starquest.DataAccess.Entities.MissionTrack", "MissionTrack")
                        .WithMany("Challenges")
                        .HasForeignKey("MissionTrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.MissionLevel", b =>
                {
                    b.HasOne("TA.Starquest.DataAccess.Entities.Mission", "Mission")
                        .WithMany("MissionLevels")
                        .HasForeignKey("MissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.MissionTrack", b =>
                {
                    b.HasOne("TA.Starquest.DataAccess.Entities.Badge", "Badge")
                        .WithMany()
                        .HasForeignKey("BadgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TA.Starquest.DataAccess.Entities.MissionLevel", "MissionLevel")
                        .WithMany("Tracks")
                        .HasForeignKey("MissionLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.Observation", b =>
                {
                    b.HasOne("TA.Starquest.DataAccess.Entities.Challenge", "Challenge")
                        .WithMany()
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TA.Starquest.DataAccess.Entities.ApplicationUser", "User")
                        .WithMany("Observations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TA.Starquest.DataAccess.Entities.UserBadge", b =>
                {
                    b.HasOne("TA.Starquest.DataAccess.Entities.Badge", "Badge")
                        .WithMany("UserBadges")
                        .HasForeignKey("BadgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TA.Starquest.DataAccess.Entities.ApplicationUser", "User")
                        .WithMany("UserBadges")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}