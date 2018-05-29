using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.CommandHandlers;
using Web.Datas;
using Web.Infrastructure;
using Web.Messages;
using Web.Storages;
using Web.Utils;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IComandBus, CommandBus>();
            services.AddScoped<IEventBus, EventBus>();
            services.AddScoped<ICommandFactory, CommandFactory>();
            services.AddScoped<IEventHandlerFactory, EventHandlerFactory>();
            services.AddScoped<IEventStorage, EventStorage>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
          //  services.AddTransient(typeof(ICommandHandler<>),typeof(CommandHandler<>))
            services.AddDbContext<RepositoryDatabase>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddJointownAuthentication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //var options = new RewriteOptions()
            //                  .AddRedirectToHttps();
            //app.UseRewriter(options);
            app.UseJointownIdentity();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute("homePage", "", new { controller = "Home", action = "Index" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
