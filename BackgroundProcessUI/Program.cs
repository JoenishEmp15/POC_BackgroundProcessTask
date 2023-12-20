using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POC_BackgroundProcess;
using BackgroundProcessUI;
using Serilog;

// To customize application configuration such as set high DPI settings or default font,
// see https://aka.ms/applicationconfiguration.
Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);

ApplicationConfiguration.Initialize();
Application.Run(new BackgroundProcessUI.BackgroundProcessUI());


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
