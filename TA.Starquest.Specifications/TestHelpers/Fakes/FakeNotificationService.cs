// This file is part of the MS.Gamification project
// 
// File: FakeNotificationService.cs  Created: 2016-11-01@19:37
// Last modified: 2016-12-13@03:32

using System.Collections.Generic;
using System.Threading.Tasks;
using MS.Gamification.BusinessLogic.Gamification;
using MS.Gamification.EmailTemplates;
using MS.Gamification.Models;
using MS.Gamification.ViewModels.Moderation;

namespace MS.Gamification.Tests.TestHelpers.Fakes
    {
    class FakeNotificationService : IGameNotificationService
        {
        public Task ObservationApprovedAsync(Observation observation)
            {
            return Task.FromResult(0);
            }

        public Task BadgeAwardedAsync(Badge badge, ApplicationUser user, MissionTrack track)
            {
            return Task.FromResult(0);
            }

        public Task PendingObservationSummaryAsync(ApplicationUser user, IEnumerable<ModerationQueueItem> observations)
            {
            return Task.FromResult(0);
            }

        public Task NotifyUsersAsync<TModel>(TModel model, string subject, IEnumerable<string> userIds) where TModel : EmailModelBase
            {
            return Task.FromResult(0);
            }
        }
    }