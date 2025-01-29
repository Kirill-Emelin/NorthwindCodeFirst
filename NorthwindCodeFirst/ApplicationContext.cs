using Microsoft.EntityFrameworkCore;

namespace NorthwindCodeFirst
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\MYSQLEXPRESS;Database=NorthwindTest;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(c => c.CategoryName)
                    .HasMaxLength(15); 

                entity.Property(c => c.Description)
                    .HasColumnType("ntext"); 
            });
        }
    }
}
