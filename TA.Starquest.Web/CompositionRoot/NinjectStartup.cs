using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ninject.Web.AspNetCore;
using Ninject.Web.AspNetCore.Hosting;
using TA.Starquest.DataAccess.EFCore;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.Web.Services.Email;

namespace TA.Starquest.Web.CompositionRoot;

/// <summary>
///     Application startup, Ninject style.
/// </summary>
public class NinjectStartup : AspNetCoreStartupBase
{
    /// <inheritdoc />
    public NinjectStartup(
        IConfiguration                                         config,
        IServiceProviderFactory<NinjectServiceProviderBuilder> providerFactory) : base(providerFactory)
    {
        Configuration = config;
    }

    public IConfiguration Configuration { get; }

    #region Overrides of AspNetCoreStartupBase

    public override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        // Add your services configuration HERE
        services.Configure<CookiePolicyOptions>(options =>
        {
            // This lambda determines whether user consent for non-essential 
            // cookies is needed for a given request.
            options.CheckConsentNeeded = context => true;
            // requires using Microsoft.AspNetCore.Http;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });

        services.AddDbContext<ApplicationDbContext>(
                                                    options => options.UseSqlite(
                                                                                 Configuration.GetConnectionString("Starquest")));

        services.AddDefaultIdentity<ApplicationUser>(
                                                     options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddTransient<IEmailSender, SendgridEmailSender>();
        services.Configure<AuthMessageSenderOptions>(Configuration);
        //services.AddAuthentication();
        services.AddAuthentication()
            .AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });

        services.AddControllersWithViews();
        services.AddRazorPages();
        services.AddApplicationInsightsTelemetry();
        services.AddDatabaseDeveloperPageExceptionFilter();
    }

    public override void Configure(IApplicationBuilder app)
    {
        // For simplicitly, there is only one overload of Configure supported, so in order to get the additional
        // services, you can just resolve them with the service provider.
        var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

        // Add your application builder configuration HERE

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //ToDo [TPL] Enable this once we have a trusted SSL certificate
            //app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.ConfigureStaticFiles(env);
        app.UseCookiePolicy(); // GDPR cookie consent
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                                         "default",
                                         "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapAreaControllerRoute(
                                             "admin",
                                             "Admin",
                                             "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            endpoints.MapRazorPages();
        });
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                                         "areas",
                                         "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                                        );
        });
    }

    #endregion
}

