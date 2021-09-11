using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResearchApplication.Areas.Identity.Data;
using ResearchApplication.Data;

[assembly: HostingStartup(typeof(ResearchApplication.Areas.Identity.IdentityHostingStartup))]
namespace ResearchApplication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ResearchApplicationDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ResearchApplicationDbContextConnection")));

                services.AddDefaultIdentity<ResearchApplicationUser>(options =>
                {

                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;

                })


                    .AddEntityFrameworkStores<ResearchApplicationDbContext>();
            });
        }
    }
}