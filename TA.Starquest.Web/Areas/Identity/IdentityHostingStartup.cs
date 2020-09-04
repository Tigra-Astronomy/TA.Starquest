using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TA.Starquest.DataAccess.EFCore;
using TA.Starquest.DataAccess.Entities;

[assembly: HostingStartup(typeof(TA.Starquest.Web.Areas.Identity.IdentityHostingStartup))]
namespace TA.Starquest.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}