// This file is part of the MS.Gamification project
// 
// File: ObservationBuilder.cs  Created: 2016-11-01@19:37
// Last modified: 2016-12-12@21:08

using System;
using System.Threading;
using MS.Gamification.Models;

namespace MS.Gamification.Tests.TestHelpers
    {
    class ObservationBuilder
        {
        const string MissingImage = "NoImage";
        // ReSharper disable once StaticMemberInGenericType
        static int uniqueId;
        readonly DataContextBuilder dcb;
        readonly ObservingEquipment equipment = ObservingEquipment.NakedEye;
        readonly string expectedImage = MissingImage;
        readonly string notes = "Lorem ipsum dolor sit amet";
        readonly string observingSite = "Nowhere";
        readonly AntoniadiScale seeing = AntoniadiScale.Unknown;
        readonly string submittedImage = MissingImage;
        readonly TransparencyLevel transparency = TransparencyLevel.Unknown;
        int challengeId = 100;
        DateTime observationDateTimeUtc = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        int observationId;
        ModerationState observationStatus = ModerationState.Approved;
        string userId = "user";

        public ObservationBuilder(DataContextBuilder dcb)
            {
            this.dcb = dcb;
            observationId = Interlocked.Increment(ref uniqueId);
            }

        public DataContextBuilder BuildObservation()
            {
            var observation = new Observation
                {
                Id = observationId,
                ChallengeId = challengeId,
                Equipment = equipment,
                ExpectedImage = expectedImage,
                Notes = notes,
                ObservationDateTimeUtc = observationDateTimeUtc,
                ObservingSite = observingSite,
                Seeing = seeing,
                Status = observationStatus,
                SubmittedImage = submittedImage,
                Transparency = transparency,
                UserId = userId
                };
            dcb.WithEntity(observation);
            return dcb;
            }

        public ObservationBuilder ForChallenge(int challengeId)
            {
            this.challengeId = challengeId;
            return this;
            }

        public ObservationBuilder ForUserId(string user)
            {
            userId = user;
            return this;
            }

        public ObservationBuilder AwaitingModeration()
            {
            observationStatus = ModerationState.AwaitingModeration;
            return this;
            }

        public ObservationBuilder WithId(int id)
            {
            observationId = id;
            return this;
            }

        public ObservationBuilder Rejected()
            {
            observationStatus = ModerationState.Rejected;
            return this;
            }

        public ObservationBuilder Approved()
            {
            observationStatus = ModerationState.Approved;
            return this;
            }

        public ObservationBuilder At(DateTime dateTime)
            {
            observationDateTimeUtc = dateTime;
            return this;
            }
        }
    }