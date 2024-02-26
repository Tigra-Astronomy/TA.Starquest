using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TA.Starquest.DataAccess.EFCore;
using TA.Starquest.DataAccess.Entities;
using TA.Starquest.Web.Services.Email;

namespace TA.Starquest.Web
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
            services.Configure<CookiePolicyOptions>(options =>
                {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            services.AddDbContext<ApplicationDbContext>(
                options=>options.UseSqlite(
                    Configuration.GetConnectionString("Starquest")));

            services.AddDefaultIdentity<ApplicationUser>(
                    options=>options.SignIn.RequireConfirmedAccount=true)
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

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            ConfigureStaticFiles(app, env);
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

        private static void ConfigureStaticFiles(IApplicationBuilder app, IWebHostEnvironment env)
            {
            int cacheMaxAgeSeconds = env.IsDevelopment()?20: 604800;;
            app.UseStaticFiles(new StaticFileOptions
                {
                OnPrepareResponse = ctx =>
                    {
                    // using Microsoft.AspNetCore.Http;
                    ctx.Context.Response.Headers.Append(
                        "Cache-Control", $"public, max-age={cacheMaxAgeSeconds}");
                    }
                });
            }
        }
    }
