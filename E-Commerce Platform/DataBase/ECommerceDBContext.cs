using E_Commerce_Platform.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;
using System.Drawing;

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

         
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Email> Emails { get;}  

    }
}
