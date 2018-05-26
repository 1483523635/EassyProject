using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Passport.Data;
using Passport.Models;
using Passport.Services;
using Microsoft.AspNetCore.DataProtection;

namespace Passport
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddDataProtection()
                  .PersistKeysToFileSystem(new System.IO.DirectoryInfo(@"E:\jointown"))
                  .SetApplicationName("SharedCookieApp");

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Domain = ".jointown.com";
                options.Cookie.Name = ".AspNet.SharedCookie";
            });


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            app.UseStaticFiles();

            app.UseAuthentication();
            SeedRoles(app).ConfigureAwait(false).GetAwaiter().GetResult();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        private async Task SeedRoles(IApplicationBuilder app)
        {

            var db_context = app.ApplicationServices.GetService<RoleManager<IdentityRole>>();
            if (!await db_context.RoleExistsAsync("admin"))
            {
                await db_context.CreateAsync(new IdentityRole("admin"));
            }
            if (!await db_context.RoleExistsAsync("enterpriseUser"))
            {
                await db_context.CreateAsync(new IdentityRole("enterpriseUser"));
            }
        }
    }
}
