// This file is part of the MS.Gamification project
// 
// File: ObservingEquipment.cs  Created: 2016-04-22@01:12
// Last modified: 2016-05-08@00:48 by Fern

using System.ComponentModel.DataAnnotations;

namespace MS.Gamification.Models
    {
    public enum ObservingEquipment
        {
        [Display(Name = "Naked Eye")]
        NakedEye,
        Binocular,
        Telescope
        }
    }
