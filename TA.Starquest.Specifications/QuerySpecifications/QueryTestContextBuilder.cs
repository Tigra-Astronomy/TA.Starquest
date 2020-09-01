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
// File: QueryTestContextBuilder.cs  Last modified: 2020-08-31@19:21 by Tim Long

using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TA.Starquest.DataAccess;
using TA.Starquest.DataAccess.EFCore;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.Specifications.QuerySpecifications
    {
    class QueryTestContextBuilder
        {
        private readonly List<Action<IUnitOfWork>> dataLoaders = new List<Action<IUnitOfWork>>();

        private SqliteConnection CreateInMemoryDatabase()
            {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            return connection;
            }

        public QueryTestContextBuilder WithStandardMission()
            {
            dataLoaders.Add(CreateStandardMissionData);
            return this;
            }

        public QueryTestContext Build()
            {
            SqliteConnection connection = CreateInMemoryDatabase();
            var dbOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            dbOptionsBuilder
                .UseSqlite(connection)
                .UseLoggerFactory(LogSetup.LogFactory)
                .EnableSensitiveDataLogging();
            var dbContext = new ApplicationDbContext(dbOptionsBuilder.Options);
            dbContext.Database.EnsureCreated();
            var uow = new EntityFrameworkCoreUnitOfWork(dbContext);
            var context = new QueryTestContext
                {
                UnitOfWork = uow,
                DbContext = dbContext,
                DbConnection = connection
                };
            foreach (var dataLoader in dataLoaders)
                {
                dataLoader(uow);
                }
            uow.Commit();
            return context;
            }

        public QueryTestContextBuilder WithUser(string id, string name)
            {
            var user = new StarquestUser
                {
                Id = id,
                UserName = name,
                NormalizedUserName = name.ToUpper()
                };
            dataLoaders.Add(uow=>uow.Users.Add(user));
            return this;
            }

        private void CreateStandardMissionData(IUnitOfWork uow)
            {
            uow.CategoriesRepository.Add(new[]
                {
                new Category {Id = 100, Name = "Phase"},
                new Category {Id = 200, Name = "Planet"},
                new Category {Id = 300, Name = "Open Cluster"},
                new Category {Id = 400, Name = "Galaxy"}
                });
            uow.Missions.Add(new Mission
                {
                Id = 1,
                Title = "Test Mission 1"
                });
            uow.MissionLevels.Add(new MissionLevel
                {
                Id = 11,
                Level = 1,
                MissionId = 1,
                Name = "Mission 1 Level 1",
                AwardTitle = "Unit Tester",
                });

            uow.Badges.Add(new[]
                {
                new Badge {Id = 111, Name = "Badge for M1 L1 T1"},
                new Badge {Id = 112, Name = "Badge for M1 L1 T2"},
                new Badge {Id = 113, Name = "Badge for M1 L1 T3"},
                });

            var missionTrack111 = new MissionTrack
                {
                Id = 1,
                AwardTitle = "Mission 1 Level 1 Track 1 award",
                Name = "Mission 1 Level 1 Track 1",
                MissionLevelId = 11,
                Number = 1,
                BadgeId = 111
                };
            var missionTrack112 = new MissionTrack
                {
                Id = 112,
                AwardTitle = "Mission 1 Level 1 Track 2 award",
                Name = "Mission 1 Level 1 Track 2",
                MissionLevelId = 11,
                Number = 2,
                BadgeId = 112
                };
            var missionTrack113 = new MissionTrack
                {
                Id = 113,
                AwardTitle = "Mission 1 Level 1 Track 3 award",
                Name = "Mission 1 Level 1 Track 3",
                MissionLevelId = 11,
                Number = 3,
                BadgeId = 113
                };
            uow.MissionTracks.Add(new[] {missionTrack111, missionTrack112, missionTrack113});
            var challenge1111 = new Challenge
            {
                Id = 1111,
                CategoryId = 100,
                Name = "See the Moon",
                MissionTrackId = 1,
                Points = 1
            };
            var challenge1112 = new Challenge
            {
                Id = 1112,
                CategoryId = 100,
                Name = "See the full Moon",
                MissionTrackId = 1,
                Points = 1
            };
            var challenge1121 = new Challenge
            {
                Id = 1121,
                CategoryId = 200,
                MissionTrackId = 112,
                Name = "See Jupiter",
                Points = 1
            };
            var challenge1122 = new Challenge
            {
                Id = 1122,
                CategoryId = 200,
                MissionTrackId = 112,
                Name = "See Saturn",
                Points = 2
            };
            var challenge1131 = new Challenge
            {
                Id = 1131,
                CategoryId = 300,
                MissionTrackId = 113,
                Name = "See the Pleiades",
                Points = 2
            };
            var challenge1132 = new Challenge
            {
                Id = 1132,
                CategoryId = 300,
                MissionTrackId = 113,
                Name = "See the Andromeda Galaxy",
                Points = 2
            };
            uow.Challenges.Add(new Challenge[]
                {
                challenge1111, challenge1112, challenge1121, challenge1122, challenge1131, challenge1132
                });
            }

        public QueryTestContextBuilder WithObservation(int observationId, string userId, int challengeId)
            {
            var observation = new Observation
                {
                Id = observationId, UserId = userId, ChallengeId = challengeId,
                Notes = "Unit test observation"
                };
            dataLoaders.Add(uow=>uow.Observations.Add(observation));
            return this;
            }

        public QueryTestContextBuilder WithObservationAwaitingModeration(int observationId, string userId, int challengeId)
            {
            var observation = new Observation
                {
                Id = observationId,
                UserId = userId,
                ChallengeId = challengeId,
                Notes = "Unit test observation awaiting moderation",
                Status = ModerationState.AwaitingModeration
                };
            dataLoaders.Add(uow => uow.Observations.Add(observation));
            return this;
            }

        public QueryTestContextBuilder WithRejectedObservation(int observationId, string userId, int challengeId)
            {
            var observation = new Observation
                {
                Id = observationId,
                UserId = userId,
                ChallengeId = challengeId,
                Notes = "Unit test observation awaiting moderation",
                Status = ModerationState.Rejected
                };
            dataLoaders.Add(uow => uow.Observations.Add(observation));
            return this;
            }

        public QueryTestContextBuilder WithApprovedObservation(int observationId, string userId, int challengeId)
            {
            var observation = new Observation
                {
                Id = observationId,
                UserId = userId,
                ChallengeId = challengeId,
                Notes = "Unit test observation awaiting moderation",
                Status = ModerationState.Approved
                };
            dataLoaders.Add(uow => uow.Observations.Add(observation));
            return this;
            }
       }
    }