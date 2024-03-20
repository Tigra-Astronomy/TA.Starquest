using Ninject;
using Ninject.Web.AspNetCore;
using Ninject.Web.AspNetCore.Hosting;
using Ninject.Web.Common.SelfHost;
using TA.Starquest.Web.CompositionRoot;

namespace TA.Starquest.Web;

public class Program
{
    public static void Main(string[] args)
    {
        //var host = CreateHostBuilder(args).Build();
        //using (var scope = host.Services.CreateScope())
        //{
        //    var db = scope.ServiceProvider.GetRequiredService<StarquestDbContext>();
        //    db.Database.Migrate();
        //}

        //host.Run();

        var hostConfiguration = new AspNetCoreHostConfiguration(args)
            .UseStartup<NinjectStartup>()
            .UseIIS()
            //.UseHttpSys()
            //.UseKestrel()
            .BlockOnStart();

        var host = new NinjectSelfHostBootstrapper(CreateNinjectKernel, hostConfiguration);
        host.Start();
    }

    private static IKernel CreateNinjectKernel()
    {
        var settings = new NinjectSettings();
        // Unfortunately, in .NET Core projects, referenced NuGet assemblies are not copied to the output directory
        // in a normal build which means that the automatic extension loading does not work _reliably_ and it is
        // much more reasonable to not rely on that and load everything explicitly.
        settings.LoadExtensions = false;

        var kernel = new AspNetCoreKernel(settings);

        kernel.Load(typeof(AspNetCoreHostConfiguration).Assembly);
        kernel.Load(new StarquestModule());

        return kernel;
    }

    //public static IHostBuilder CreateHostBuilder(string[] args) =>
    //    Host.CreateDefaultBuilder(args)
    //        .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}