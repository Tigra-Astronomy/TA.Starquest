using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TA.Starquest.DataAccess.Entities
{
public class UserBadge
        {
        public UserBadge()
            {
            Awarded = DateTime.UtcNow;
            }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int BadgeId { get; set; }
        public Badge Badge { get; set; }
        public DateTime Awarded { get; set; }
        }
}
