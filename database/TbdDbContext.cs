namespace database
{
    using Microsoft.EntityFrameworkCore;

    public sealed class TbdDbContext : DbContext
    {
        public TbdDbContext(DbContextOptions<TbdDbContext> options)
            : base(options)
        {
        }

        public static void Configure(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("name=tbd");
        }
    }
}