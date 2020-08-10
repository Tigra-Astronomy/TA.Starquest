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
// File: FileNameWithoutPathAttribute.cs  Last modified: 2020-08-09@21:31 by Tim Long

using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace TA.Starquest.DataAccess.Validation
    {
    /// <summary>Validation data annotation that checks for a valid file name (with no directory or path).</summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    [AttributeUsage(AttributeTargets.Property)]
    sealed class FileNameWithoutPathAttribute : ValidationAttribute
        {
        #region Overrides of ValidationAttribute
        /// <summary>Determines whether the specified value of the object is valid.</summary>
        /// <returns><c>true</c> if the specified value is valid; otherwise, <c>false</c>.</returns>
        /// <param name="value">The value of the object to validate. </param>
        public override bool IsValid(object value)
            {
            //ToDo: add custom file name validation
            var name = value as string;
            if (string.IsNullOrWhiteSpace(name))
                return false;
            var invalid = Path.GetInvalidFileNameChars();
            foreach (var c in invalid)
                {
                if (name.Contains(c))
                    return false; // Contains invalid filename character.
                }
            var segments = name.Split('.');
            if (segments.Length < 2)
                return false; // Must be filename.extension
            return true; // Valid.
            }
        #endregion
        }
    }