// This file is part of the MS.Gamification project
// 
// File: PicklistItem.cs  Created: 2016-05-10@22:28
// Last modified: 2016-07-09@23:11

namespace TA.Starquest.Core
    {
    /// <summary>
    ///     Represents a key-value pair that can be used in a select (drop-down) field in a view
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public class PickListItem<TKey>
        {
        public PickListItem()
            {
            DisplayName = string.Empty;
            }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public PickListItem(TKey id, string displayName)
            {
            Id = id;
            DisplayName = displayName;
            }

        public TKey Id { get; set; }

        public string DisplayName { get; set; }
        }
    }