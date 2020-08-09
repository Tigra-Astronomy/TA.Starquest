// This file is part of the MS.Gamification project
// 
// File: FileNameWithoutPathAttribute.cs  Created: 2016-04-22@01:04
// Last modified: 2016-04-22@01:05 by Fern

using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace TA.Starquest.Web.Validation
    {
    /// <summary>
    ///   Validation data annotation that checks for a valid file name (with no directory or path).
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    [AttributeUsage(AttributeTargets.Property)]
    sealed class FileNameWithoutPathAttribute : ValidationAttribute
        {
        #region Overrides of ValidationAttribute
        /// <summary>
        ///   Determines whether the specified value of the object is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified value is valid; otherwise, <c>false</c>.
        /// </returns>
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
            return true;    // Valid.
            }
        #endregion
        }
    }
