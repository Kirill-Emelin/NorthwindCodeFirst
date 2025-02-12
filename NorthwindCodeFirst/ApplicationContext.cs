using Microsoft.EntityFrameworkCore;

namespace NorthwindCodeFirst
{
    // Контекст базы данных
    public class ApplicationContext : DbContext
    {
        // Таблицы базы данных
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        // Настройка подключения к базе данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\MYSQLEXPRESS;Database=NorthwindTest;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        // Конфигурация модели (настройка таблиц и связей)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурация таблицы Categories
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryID); // ключ категории

                entity.Property(e => e.CategoryName)
                      .HasMaxLength(15)
                      .IsRequired();

                entity.Property(e => e.Description)
                      .HasColumnType("ntext");

                entity.Property(e => e.Picture)
                      .HasColumnType("image");
            });

            // Конфигурация таблицы Products
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductID); // ключ продукта

                entity.Property(e => e.ProductName)
                      .HasMaxLength(40)
                      .IsRequired();

                entity.Property(e => e.SupplierID);

                entity.Property(e => e.CategoryID);

                entity.Property(e => e.QuantityPerUnit)
                      .HasMaxLength(20);

                entity.Property(e => e.UnitPrice)
                      .HasColumnType("money");

                entity.Property(e => e.UnitsInStock)
                      .HasColumnType("smallint");

                entity.Property(e => e.UnitsOnOrder)
                      .HasColumnType("smallint");

                entity.Property(e => e.ReorderLevel)
                      .HasColumnType("smallint");

                entity.Property(e => e.Discontinued)
                      .IsRequired();

                // Связь: много продуктов -> одна категория
                entity.HasOne(e => e.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(e => e.CategoryID);
            });

            // Конфигурация таблицы Orders
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderID); // ключ заказа

                entity.Property(e => e.CustomerID)
                      .HasColumnType("nchar(5)");

                entity.Property(e => e.OrderDate)
                      .HasColumnType("datetime");

                entity.Property(e => e.RequiredDate)
                      .HasColumnType("datetime");

                entity.Property(e => e.ShippedDate)
                      .HasColumnType("datetime");

                entity.Property(e => e.Freight)
                      .HasColumnType("money");

                entity.Property(e => e.ShipName)
                      .HasMaxLength(40);

                entity.Property(e => e.ShipAddress)
                      .HasMaxLength(60);

                entity.Property(e => e.ShipCity)
                      .HasMaxLength(15);

                entity.Property(e => e.ShipRegion)
                      .HasMaxLength(15);

                entity.Property(e => e.ShipPostalCode)
                      .HasMaxLength(10);

                entity.Property(e => e.ShipCountry)
                      .HasMaxLength(15);
            });

            // Конфигурация таблицы OrderDetails
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderID, e.ProductID }); // составной ключ

                entity.Property(e => e.UnitPrice)
                      .HasColumnType("money");

                entity.Property(e => e.Quantity)
                      .HasColumnType("smallint");

                entity.Property(e => e.Discount)
                      .HasColumnType("real");

                // Связь: детали заказа -> заказ
                entity.HasOne(e => e.Order)
                      .WithMany(o => o.OrderDetails)
                      .HasForeignKey(e => e.OrderID);

                // Связь: детали заказа -> продукт
                entity.HasOne(e => e.Product)
                      .WithMany(p => p.OrderDetails)
                      .HasForeignKey(e => e.ProductID);
            });
        }
    }
}
