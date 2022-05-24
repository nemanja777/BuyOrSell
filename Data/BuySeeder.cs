using BuyOrSell.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BuyOrSell.Data
{
    public class BuySeeder
    {
        private readonly BuyContext _ctx;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;

        public BuySeeder(BuyContext ctx, IWebHostEnvironment env, UserManager<ApplicationUser> userManager)
        {
            _ctx = ctx;
            _env = env;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();

            ApplicationUser user = await _userManager.FindByEmailAsync("milosevic93@gmail.com");
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    FirstName = "Nemanja",
                    Lastname = "Milosevic",
                    Email = "milosevic93@gmail.com",
                    UserName = "milosevic93@gmail.com",
                    Id = "1"
                };

                var result = await _userManager.CreateAsync(user, "P1@sswOrd");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create user in seeder");
                }
            }

            if (!_ctx.Ads.Any())
            {
                //Need to create sample data
                var filePath = Path.Combine (_env.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filePath);
                var ads = JsonSerializer.Deserialize<IEnumerable<Ad>>(json);

               

                    _ctx.Ads.AddRange(ads);

                _ctx.SaveChanges(); 
            }
        }
    }
}
