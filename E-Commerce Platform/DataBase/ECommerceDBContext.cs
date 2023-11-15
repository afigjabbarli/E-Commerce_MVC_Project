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

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Email>()
            .HasOne<User>(e => e.User)
            .WithMany(u => u.Emails)
            .HasForeignKey(e => e.UserId);
            ///UserVerificationToken start region

            modelBuilder.Entity<UserVerificationToken>()
                .HasOne<User>(uvt => uvt.User)
                .WithMany(u => u.VerificationTokens)
                .HasForeignKey(uvt => uvt.UserID);

            ///UserVerificationToken end region

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
                    Id = -7,
                    Name = "Yellow",
                    Code = "#fbff00"
                },
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -6,
                    Name = "Green",
                    Code = "#04b40f"
                },
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -5,
                    Name = "Black",
                    Code = "#000000"
                },
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -4,
                    Name = "Gray",
                    Code = "#666666"
                },
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -3,
                    Name = "Blue",
                    Code = "#0052d6"
                },
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -2,
                    Name = "White",
                    Code = "#ffffff"
                },
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -1,
                    Name = "Red",
                    Code = "#ff0000"
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
                    Name = "Phones, tablets and gadgets",
                    Description = "<<Phones, tablets, and gadgets>> refer to a diverse range of modern electronic devices. This category includes smartphones for communication, tablets for work and play, and various gadgets to enhance your digital life. Explore the latest in technology, connectivity, and convenience in this dynamic category."
                },
                new Category
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -6,
                    Name = "Televisions, audio-video and photography",
                    Description = "<<Televisions, audio-video, and photography>> encompass the world of visual and auditory experiences. Within this category, you can find cutting-edge TVs for immersive viewing, audio equipment to elevate your sound, and photography gear to capture life's memorable moments. Dive into a world of stunning sights and sounds with these products."
                },
                new Category
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -5,
                    Name = "Laptops and computer equipment",
                    Description = "<<Laptops and computer equipment>> provide the tools you need to stay connected and productive in the digital age. This category offers a range of laptops and essential computer peripherals and accessories. Whether you need a powerful laptop for work or play or require computer equipment to enhance your setup, you'll find it here."
                },
                new Category
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -4,
                    Name = "Air conditioners and other climate equipment",
                    Description = "Air conditioners and other climate equipment includes a variety of devices designed to control the temperature and climate of your living or working space. This category offers a selection of air conditioners, heaters, fans, and other climate control equipment to help you create a comfortable environment in any season."
                },
                new Category
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -3,
                    Name = "Major Home Appliances",
                    Description = "<<Major home appliances>> refers to large, essential electrical machines commonly used in households to perform various tasks. These appliances are typically permanent fixtures and include items like refrigerators, washing machines, dryers, ovens, stoves, dishwashers, and more. They play a crucial role in modern living by simplifying daily tasks and enhancing overall household efficiency."
                },
                new Category
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -2,
                    Name = "Small Appliances",
                    Description = "<<Small appliances>> are compact and portable electrical devices designed to perform specific tasks in households. These appliances are typically used for various kitchen, cleaning, and personal care purposes. Examples of small appliances include toasters, blenders, coffee makers, electric kettles, microwave ovens, vacuum cleaners, irons, hair dryers, and more. Small appliances are known for their convenience, as they make daily chores and routines more manageable."
                },
                new Category
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -1,
                    Name = "Game consoles",
                    Description = "Game consoles and accessories refer to the hardware and peripherals used for playing video games. Game consoles are specialized electronic devices designed primarily for gaming and typically come with built-in gaming capabilities, controllers, and other features. Accessories, on the other hand, are add-ons or enhancements that can improve the gaming experience. Common game consoles include products from companies like Sony (PlayStation), Microsoft (Xbox), and Nintendo, while accessories can encompass items like extra controllers, virtual reality headsets, gaming keyboards and mice, steering wheels, and more. Gamers often invest in these accessories to enhance their gameplay and overall enjoyment of video games."
                }
            );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Email> Emails { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }  
        public DbSet<UserVerificationToken> UserVerificationTokens { get; set; }    

    }
}
