// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;
using RecipeService;
using RecipeService.Data;
using RecipeService.Data.Repositories;
using Serilog;

Console.WriteLine("Hello, World!");

IConfiguration _config = InitializeConfiguration();

ConfigureLogging(_config);

ConfigureServices(_config);

void ConfigureServices(IConfiguration configuration)
{
    using IHost host = Host.CreateDefaultBuilder(args)
        .UseWindowsService(options =>
        {
            options.ServiceName = "Recipe Service";
        }).ConfigureServices((_, services) =>
        {
            services.AddDbContext<RecipeContext>(options => options.UseSqlServer(configuration["RecipeContext"]));
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddHostedService<RecipeSyncService>();
        }).Build();

    host.Run();
    
}

void ConfigureLogging(IConfiguration configuration)
{
    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.File("test", rollingInterval: RollingInterval.Day)
        .CreateLogger();
}

IConfiguration InitializeConfiguration()
{
    string environment = "release";

#if DEBUG
    environment = "development";
#endif

    if (environment == "development")
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.{environment}.json", optional: false);

        return builder.Build();
    } else
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        return builder.Build();
    }
}
