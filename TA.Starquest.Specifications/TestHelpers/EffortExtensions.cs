// This file is part of the MS.Gamification project
// 
// File: EffortExtensions.cs  Created: 2016-05-22@06:29
// Last modified: 2016-05-22@06:47

using System.Collections.Generic;

namespace MS.Gamification.Tests.TestHelpers
    {
    static class EffortExtensions
        {
        public static ICollection<T> Add<T>(this ICollection<T> collection, params T[] items) where T : class
            {
            foreach (var item in items)
                {
                collection.Add(item);
                }
            return collection;
            }
        }
    }