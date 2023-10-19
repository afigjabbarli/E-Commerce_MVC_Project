using E_Commerce_Platform.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Color = E_Commerce_Platform.DataBase.Models.Color;
using Size = E_Commerce_Platform.DataBase.Models.Size;

namespace E_Commerce_Platform.DataBase
{
    public class ECommerceDBContext : DbContext
    {
        public ECommerceDBContext(DbContextOptions<ECommerceDBContext> options)
        : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>()
            .HasOne<User>(e => e.User)
            .WithMany(u => u.Emails)
            .HasForeignKey(e => e.UserId);

            base.OnModelCreating(modelBuilder);

            ///CategoryProduct start region

            modelBuilder.Entity<CategoryProduct>().HasKey(cp => new { cp.ProductId, cp.CategoryId });

            modelBuilder.Entity<CategoryProduct>()
                 .HasOne<Category>(cp => cp.Category)
                 .WithMany(c => c.CategoryProducts)
                 .HasForeignKey(cp => cp.CategoryId);

            modelBuilder.Entity<CategoryProduct>()
                .HasOne<Product>(cp => cp.Product)
                .WithMany(p => p.CategoryProducts)
                .HasForeignKey(cp => cp.ProductId);

            ///CategoryProduct end region

            ///ProductSize start region

            modelBuilder.Entity<ProductSize>().HasKey(ps => new { ps.ProductId, ps.SizeId });

            modelBuilder.Entity<ProductSize>()
                .HasOne<Size>(ps => ps.Size)
                .WithMany(s => s.ProductSizes)
                .HasForeignKey(ps => ps.SizeId);

            modelBuilder.Entity<ProductSize>()
                .HasOne<Product>(ps => ps.Product)
                .WithMany(p => p.ProductSizes)
                .HasForeignKey(ps => ps.ProductId);

            ///ProductSize end region



            ///ProductColor start region
            modelBuilder.Entity<ProductColor>().HasKey(pc => new { pc.ProductId, pc.ColorId });

            modelBuilder.Entity<ProductColor>()
                .HasOne<Color>(pc => pc.Color)
                .WithMany(c => c.ProductColors)
                .HasForeignKey(pc => pc.ColorId);

            modelBuilder.Entity<ProductColor>()
                .HasOne<Product>(pc => pc.Product)
                .WithMany(p => p.ProductColors)
                .HasForeignKey(pc => pc.ProductId);


            ///ProductColor end region

            /// Color Seeding started
            modelBuilder.Entity<Color>().HasData
            (
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -5,
                    Name = "Black"
                },
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -4,
                    Name = "Gray"
                },
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -3,
                    Name = "Blue"
                },
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -2,
                    Name = "White"
                },
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -1,
                    Name = "Red"
                }
            );
            ////// Color Seeding ended

            //////Size seeding started

            modelBuilder.Entity<Size>().HasData
            (
                new Size
                {

                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -7,
                    Name = "XXS"
                },
                new Size
                {

                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -6,
                    Name = "XS"
                },
                new Size
                {

                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -5,
                    Name = "S"
                },
                new Size
                {

                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -4,
                    Name = "M"
                },
                new Size
                {

                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -3,
                    Name = "L"
                },
                new Size
                {

                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -2,
                    Name = "XL"
                },
                 new Size
                 {

                     UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                     CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                     Id = -1,
                     Name = "XXL"
                 }
            );

            ////// Color Seeding ended

            ////// Category Seeding started

            modelBuilder.Entity<Category>().HasData
            (
                new Category
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -7,
                    Name = "Phones, tablets and gadgets"
                },
                new Category
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -6,
                    Name = "Televisions, audio-video and photography"
                },
                new Category
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -5,
                    Name = "Laptops and computer equipment"
                },
                new Category
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -4,
                    Name = "Air conditioners and other climate equipment"
                },
                new Category
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -3,
                    Name = "Major Home Appliances"
                },
                new Category
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -2,
                    Name = "Small Appliances"
                },
                new Category
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -1,
                    Name = "Game consoles and accessories"
                }
            );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Email> Emails { get; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }  

    }
}
