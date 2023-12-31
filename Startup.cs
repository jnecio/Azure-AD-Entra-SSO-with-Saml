﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Sustainsys.Saml2.Metadata;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace RaadTestSSO
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // ... other configurations
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "SAML"; // Your SAML authentication scheme
            })
            .AddCookie()
            .AddSaml2("SAML", options =>
            {
                // Configure your SAML options here, including the ACS URL.
                options.SPOptions.EntityId = new EntityId("RaadSamlToolKit");
                options.SPOptions.ReturnUrl = new Uri("https://raadtest.azurewebsites.net/SAML/AssertionConsumerService");
                // ... other SAML options
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            // ... other middleware configurations
            app.UseAuthentication();

            var builder = WebApplication.CreateBuilder();
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            var buildApp = builder.Build();

            // Configure the HTTP request pipeline.
            if (!buildApp.Environment.IsDevelopment())
            {
                buildApp.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                buildApp.UseHsts();
            }
            buildApp.UseSession();
            buildApp.UseHttpsRedirection();
            buildApp.UseStaticFiles();
            buildApp.UseRouting();
            buildApp.UseAuthorization();
            buildApp.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Login}");

            buildApp.Run();


        }

    }
}
