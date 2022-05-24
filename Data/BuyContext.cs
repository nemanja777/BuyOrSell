using BuyOrSell.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyOrSell.Data
{
    public class BuyContext : DbContext
    {
        public BuyContext(DbContextOptions<BuyContext> options) : base(options)
        {

        }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Ad>()
                .HasData(new Ad()
                {
                    Id = 1,
                    Name = "OGLAS765756765",
                    Description = "NOVO NOVO NOVO",
                    Url = "https://www.ikea.com/rs/sr/p/stefan-stolica-smede-crna-00211088/",
                    Price = 99.99,
                    Cattegory = "NAMESTAJ",
                    Town = "Novi Sad",
                    Date = DateTime.UtcNow


                });
        }





    }
}
