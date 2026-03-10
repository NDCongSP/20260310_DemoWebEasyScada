public class ApplicationDbContext : DbContext, IDisposable, IObjectContextAdapter
{
    // Ensure the constructor is public so it can be accessed from Form1
    public ApplicationDbContext()
        : base("name=DefaultConnection") // Adjust connection string name as needed
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Existing implementation
    }

    public virtual DbSet<RealtimeData> RealtimeDatas { get; set; }
    public virtual DbSet<RevoConfig> RevoConfigs { get; set; }
}