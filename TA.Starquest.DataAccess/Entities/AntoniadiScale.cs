// This file is part of the TA.Starquest project
// 
// Copyright � 2015-2020 Tigra Astronomy, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: AntoniadiScale.cs  Last modified: 2020-08-09@21:31 by Tim Long

using System.ComponentModel.DataAnnotations;

namespace TA.Starquest.DataAccess.Entities
    {
    public enum AntoniadiScale
        {
        Unknown,

        [Display(Name = "I - Perfectly Stable")]
        PerfectlyStable,

        [Display(Name = "II - Mostly Stable")] MostlyStable,

        [Display(Name = "III - Mostly Stable")]
        SomewhatStable,

        [Display(Name = "IV - Unstable")] Unstable,

        [Display(Name = "V - Very Unstable")] VeryUnstable
        }
    }