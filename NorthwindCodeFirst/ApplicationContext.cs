using Microsoft.EntityFrameworkCore;

namespace NorthwindCodeFirst
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Northwind.db");
        }
    }
}
