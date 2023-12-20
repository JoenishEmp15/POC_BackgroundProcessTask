using POC_BackgroundProcess;
using Serilog;

//logger configuration for logging in text file
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.File("BackgroundProcessLogs/BackgroundProcesslog.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
var builder = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<BackGroundProcess>();
        services.AddLogging();
    })
    .ConfigureLogging((hostContext, logging) =>
    {
        logging.AddSerilog();
    });
var host = builder.Build();
host.Run();