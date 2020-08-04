namespace tbd.database
{
    using Microsoft.EntityFrameworkCore;

    public sealed class TbdDbContext : DbContext
    {
        public TbdDbContext(DbContextOptions<TbdDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>();
        }

        public static void Configure(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("name=tbd");
        }
    }
}