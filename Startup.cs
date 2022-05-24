using BuyOrSell.Data;
using BuyOrSell.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyOrSell.Data.Entities;

namespace BuyOrSell
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddIdentity<ApplicationUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;

            })
            .AddEntityFrameworkStores<BuyContext>();

            services.AddDbContext<BuyContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("BuyContextDb")));



            services.AddTransient<BuySeeder>();

            //services.AddTransient<IMailService>();
            //services.AddScoped<TaskService>()

            services.AddScoped<IMailService, NullMailService>();



            //services.AddHttpContextAccessor();

            services.AddScoped<IBuyRepository, BuyRepository>();


            services.AddMvc();


            services.AddControllersWithViews()
                    .AddRazorRuntimeCompilation();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Ads}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
