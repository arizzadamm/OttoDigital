using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OttoDigital.Areas.Identity.Data;
using OttoDigital.Data;

[assembly: HostingStartup(typeof(OttoDigital.Areas.Identity.IdentityHostingStartup))]
namespace OttoDigital.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<OttoDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("OttoDbContextConnection")));

                services.AddDefaultIdentity<OttoDigitalUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 2;
                    options.Password.RequireNonAlphanumeric = false;

                })
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<OttoDbContext>();
            });
        }
    }
}