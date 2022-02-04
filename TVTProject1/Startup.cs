////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Project:        Project1
//  File Name:      Project1.cs
//  Description:    MVC Dice roll, Encryption, Decryption, and 
//  Course:         CSCI-3110-001
//  Author:         Taylor Tillman, tillmant@etsu.edu
//  Created:        Tuesday, September 21, 2021
//  Copyright:      Taylor Tillman, 2021
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVTProject1.Services;

namespace TVTProject1
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
            services.AddControllersWithViews();
            services.AddSingleton<IDiceRollService, DiceRollService>();
            services.AddSingleton<IEncryptService, EncryptService>();
            services.AddSingleton<IDecryptService, DecryptService>();
            services.AddSingleton<IVerticalBarService, VerticalBarService>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "RollDice",
                    pattern: "RollDice/{count?}/{sides?}",
                    defaults: new { controller = "RollDice", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "Encrypt",
                    pattern: "Encrypt/{numToEncrypt?}",
                    defaults: new { controller = "Encrypt", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "Decrypt",
                    pattern: "Decrypt/{numToDecrypt?}",
                    defaults: new { controller = "Decrypt", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "VBarGraph",
                    pattern: "VBarGraph/{*Bars}",
                    defaults: new { controller = "VBarGraph", action = "Index" });
            });
        }
    }
}
