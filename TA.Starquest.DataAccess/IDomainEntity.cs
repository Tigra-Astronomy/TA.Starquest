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
// File: IDomainEntity.cs  Last modified: 2020-08-09@21:31 by Tim Long

using System.ComponentModel.DataAnnotations;

namespace TA.Starquest.DataAccess
    {
    /// <summary>
    ///     A marker interface that must be present on all domain entities. This ensures that all domain
    ///     entities contain an <see cref="Id" /> property and also serves as a constraint on the types
    ///     that can be used with the <see cref="IRepository{TEntity,TKey}" /> interface.
    /// </summary>
    public interface IDomainEntity<TKey>
        {
        /// <summary>
        ///     Gets an identifier that uniquely identifies this entity from all other entities of the
        ///     same type.
        /// </summary>
        /// <value>The identifier.</value>
        [ScaffoldColumn(false)] // Don't create an input field for this column in MVC views
        [Required]
        [Key] // This will be the primary key for the database table
        TKey Id { get; set; }
        }
    }