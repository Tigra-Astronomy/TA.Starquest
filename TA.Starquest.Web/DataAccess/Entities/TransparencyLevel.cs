// This file is part of the MS.Gamification project
// 
// File: TransparencyLevel.cs  Created: 2016-05-10@22:29
// Last modified: 2016-07-10@01:40

using System.ComponentModel.DataAnnotations;

namespace MS.Gamification.Models
    {
    public enum TransparencyLevel
        {
        Unknown,
        [Display(Name = "Extremely Clear")] ExtremelyClear,
        Clear,
        [Display(Name = "Mostly Clear")] MostlyClear,
        [Display(Name = "Somewhat Clear")] SomewhatClear,
        Poor
        }
    }