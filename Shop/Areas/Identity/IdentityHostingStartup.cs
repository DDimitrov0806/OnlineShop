using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using Shop.Data.Models;
using Shop.Models;

[assembly: HostingStartup(typeof(Shop.Areas.Identity.IdentityHostingStartup))]
namespace Shop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ShopDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ShopContextConnection")));

                services.AddDefaultIdentity<User>()
                    .AddEntityFrameworkStores<ShopDbContext>();
            });
        }
    }
}