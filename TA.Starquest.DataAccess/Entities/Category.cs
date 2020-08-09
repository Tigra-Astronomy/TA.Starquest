// This file is part of the MS.Gamification project
// 
// File: Category.cs  Created: 2016-05-10@22:28
// Last modified: 2016-08-19@03:17

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA.Starquest.DataAccess.Entities
    {
    public class Category : IDomainEntity<int>
        {
        [Required]
        [Display(Name = "Category")]
        public string Name { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        }
    }