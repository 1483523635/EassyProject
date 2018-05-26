using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class CookieMiddleWare
    {
        public static IApplicationBuilder UseJointownIdentity(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseWhen(context => context.Request.Path.Value == "/Account/Login", builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.Redirect("https://passport.jointown.com/Account/Login" + context.Request.QueryString);
                    await Task.CompletedTask;
                });
            });
            app.UseWhen(context => context.Request.Path.Value == "/Account/Logout", builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.Redirect("https://passport.jointown.com//Account/Logout" + context.Request.QueryString);
                    await Task.CompletedTask;
                });
            });
            return app;
        }
        public static IServiceCollection AddJointownAuthentication(this IServiceCollection services)
        {
            services.AddDataProtection()
              .PersistKeysToFileSystem(new System.IO.DirectoryInfo(@"E:\jointown"))
              .SetApplicationName("SharedCookieApp");

            services.AddAuthentication("Identity.Application")
                .AddCookie("Identity.Application", options =>
                {
                    options.Cookie.Domain = ".jointown.com";
                    options.Cookie.Name = ".AspNet.SharedCookie";
                });
            return services;
        }
    }
}
