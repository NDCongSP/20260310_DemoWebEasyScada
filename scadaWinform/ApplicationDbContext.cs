using System.Data.Entity;

namespace scadaWinform
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DbConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<RealtimeData> RealtimeDatas { get; set; }
        public virtual DbSet<RevoConfig> RevoConfigs { get; set; }
    }
}
