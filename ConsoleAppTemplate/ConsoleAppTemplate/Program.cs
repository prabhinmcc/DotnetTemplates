using ConsoleAppTemplate.BI;
using ConsoleAppTemplate.Resources;
using ConsoleAppTemplate.Services.Sample;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);



#region Configuration Setting section

builder.Configuration.Sources.Clear();
IHostEnvironment env = builder.Environment;
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

ApplicationConfiguration options = new();
builder.Configuration.GetSection(nameof(ApplicationConfiguration)) .Bind(options);
Console.WriteLine(options.GeneralConfiguration.ApplicationName);
#endregion 

#region Configuration - Logging
builder.Logging.ClearProviders();
builder.Logging
    .AddConsole(config =>
    {

    })
    .AddEventLog(config =>
    {
        config.SourceName = options.GeneralConfiguration.ApplicationName;
    });
#endregion
#region Services 
builder.Services.AddHostedService<MyApplicationHostedService>();
builder.Services.AddSingleton<ApplicationConfiguration>(options);
builder.Services.AddTransient<ISampleService, SampleService>();
builder.Services.AddTransient< StartupSolution>();
#endregion

using IHost host = builder.Build();

using (host)
{
    await host.StartAsync();    
}

