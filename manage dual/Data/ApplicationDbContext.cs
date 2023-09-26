using Azure;
using manage_dual.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace manage_dual.NewFolder
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //one to one
        public DbSet<client> client { get; set; }

        //many to many
        DbSet<client> clients { get; set; }
        DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

   
        modelBuilder.Entity<client>().HasData(
            new client { clientId = 0, Name = "Ahmad", PhoneNumber = "079649321763", Email = "Ahmad3323@gmail.com", Address = "St 124", City = "Amman", PostalCode = "342667" },
                new client { clientId = 2, Name = "Ali", PhoneNumber = "07964421763", Email = "Ali3323@gmail.com", Address = "St 1324", City = "Amman", PostalCode = "134667" },
                new client { clientId = 3, Name = "Yaser", PhoneNumber = "079649351763", Email = "Yaser4323@gmail.com", Address = "St 1214", City = "Amman", PostalCode = "142667" },
                new client { clientId = 4, Name = "khaled", PhoneNumber = "079649521763", Email = "khaled4323@gmail.com", Address = "St 1244", City = "Amman", PostalCode = "242667" },
                new client { clientId = 5, Name = "mhmod", PhoneNumber = "079649321763", Email = "mhmod4323@gmail.com", Address = "St 1224", City = "Amman", PostalCode = "352667" },
                new client { clientId = 6, Name = "mustafa", PhoneNumber = "079149321762", Email = "mustafa4323@gmail.com", Address = "St 1264", City = "Amman", PostalCode = "842667" }
                );




            //one to one still not sure about the relationship 
            modelBuilder.Entity<client>()
            .HasOne(e => e.Selles)
            .WithOne(e => e.client)
            .HasForeignKey<selles>(e => e.ClientForeignKey);


            //one to many between client and payment - the client have many payment , each payment have 1 client
            modelBuilder.Entity<client>()
                .HasMany(e => e.Payment)
                .WithOne(e => e.client)
                .HasForeignKey(e => e.ClientId);
                


        }

    }
}
