using Microsoft.EntityFrameworkCore;

namespace List12.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        { 
        }
        public DbSet<Article> Article { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
