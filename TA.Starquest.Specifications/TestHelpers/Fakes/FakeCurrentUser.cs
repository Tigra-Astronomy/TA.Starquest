// This file is part of the MS.Gamification project
// 
// File: FakeCurrentUser.cs  Created: 2016-07-03@23:15
// Last modified: 2016-07-03@23:39

using System.Security.Principal;
using MS.Gamification.DataAccess;

namespace MS.Gamification.Tests.TestHelpers.Fakes
    {
    class FakeCurrentUser : ICurrentUser
        {
        readonly IIdentity identity;

        public FakeCurrentUser(IIdentity identity, string id)
            {
            this.identity = identity;
            UniqueId = id;
            }

        public string DisplayName => $"{identity.Name} (unit test)";

        public string LoginName => identity.Name;

        public string UniqueId { get; }

        public bool IsAuthenticated => identity.IsAuthenticated;
        }
    }