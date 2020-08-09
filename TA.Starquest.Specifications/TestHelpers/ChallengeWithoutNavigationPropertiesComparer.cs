using System.Collections.Generic;
using MS.Gamification.Models;

namespace MS.Gamification.Tests.TestHelpers
    {
    class ChallengeWithoutNavigationPropertiesComparer : IEqualityComparer<Challenge>
        {
        public bool Equals(Challenge x, Challenge y)
            {
            return x.Id == y.Id && x.BookSection == y.BookSection && x.CategoryId == y.CategoryId && x.Location == y.Location &&
                   x.Name == y.Name && x.Points == y.Points && x.ValidationImage == y.ValidationImage;
            }

        public int GetHashCode(Challenge obj)
            {
            throw new System.NotImplementedException();
            }
        }
    }