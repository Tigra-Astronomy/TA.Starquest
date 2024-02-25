// This file is part of the TA.Starquest project
// Copyright © 2015-2024 Timtek Systems Limited, all rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so. The Software comes with no warranty of any kind.
// You make use of the Software entirely at your own risk and assume all liability arising from your use thereof.
// 
// File: MissionTrackViewModel.cs  Last modified: 2024-2-25@19:12 by Tim

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TA.Starquest.Web.ViewModels;

public class MissionTrackViewModel
{
    [Required]
    [Display(Name = "Track Name")]
    public string Name { get; set; }

    /// <summary>
    ///     Track number determines the order in which tracks are displayed.
    /// </summary>
    /// <value>The number.</value>
    [Display(Name = "Track Number")]
    public int Number { get; set; }


    [Required]
    [Display(Name = "Award Title")]
    public string AwardTitle { get; set; }

    [Display(Name = "Badge ID")] public virtual int BadgeId { get; set; }

    [Display(Name = "Level ID")] public virtual int MissionLevelId { get; set; }

    public int Id { get; set; }

    public IEnumerable<SelectListItem> BadgePicker { get; set; }

    public IEnumerable<SelectListItem> LevelPicker { get; set; }

    public string MissionLevelName { get; set; }

    public string BadgeImageIdentifier { get; set; }

    public override string ToString() =>
        $"Id: {Id}, Name: {Name}, Number: {Number}, AwardTitle: {AwardTitle}, BadgeId: {BadgeId}, MissionLevelId: {MissionLevelId}";
}
