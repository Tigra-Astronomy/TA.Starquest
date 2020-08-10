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
// File: PicklistItem.cs  Last modified: 2020-08-09@21:29 by Tim Long

namespace TA.Starquest.Core
    {
    /// <summary>Represents a key-value pair that can be used in a select (drop-down) field in a view</summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public class PickListItem<TKey>
        {
        public PickListItem()
            {
            DisplayName = string.Empty;
            }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public PickListItem(TKey id, string displayName)
            {
            Id = id;
            DisplayName = displayName;
            }

        public TKey Id { get; set; }

        public string DisplayName { get; set; }
        }
    }