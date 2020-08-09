using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TA.Starquest.DataAccess.Entities;

namespace TA.Starquest.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<StarquestUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public virtual DbSet<Challenge> Challenges { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<MissionLevel> MissionLevels { get; set; }
        public virtual DbSet<MissionTrack> MissionTracks { get; set; }
        public virtual DbSet<Observation> Observations { get; set; }
        public virtual DbSet<Mission> Missions { get; set; }
        public virtual DbSet<Badge> Badges { get; set; }
        public virtual DbSet<ObservingSession> ObservingSessions { get; set; }
        public virtual DbSet<QueuedWorkItem> QueuedWorkItems { get; set; }
    }
}
