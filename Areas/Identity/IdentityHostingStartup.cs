using System;
using Article_Review_MVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Article_Review_MVC.Areas.Identity.IdentityHostingStartup))]
namespace Article_Review_MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Article_Review_MVCIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Article_Review_MVCIdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Article_Review_MVCIdentityContext>();
            });
        }
    }
}