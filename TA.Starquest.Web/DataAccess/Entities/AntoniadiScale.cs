// This file is part of the MS.Gamification project
// 
// File: AntoniadiScale.cs  Created: 2016-05-10@22:29
// Last modified: 2016-07-10@01:40

using System.ComponentModel.DataAnnotations;

namespace MS.Gamification.Models
    {
    public enum AntoniadiScale
        {
        Unknown,

        [Display(Name = "I - Perfectly Stable")] PerfectlyStable,

        [Display(Name = "II - Mostly Stable")] MostlyStable,

        [Display(Name = "III - Mostly Stable")] SomewhatStable,

        [Display(Name = "IV - Unstable")] Unstable,

        [Display(Name = "V - Very Unstable")] VeryUnstable
        }
    }