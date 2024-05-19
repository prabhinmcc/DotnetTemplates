﻿using ConsoleAppTemplate.Services.Sample;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace ConsoleAppTemplate.BI
{
    public sealed class MyApplicationHostedService :  IHostedLifecycleService
    {
        private readonly ILogger _logger;
        private readonly ISampleService _sampleService;

        public MyApplicationHostedService(ILogger<MyApplicationHostedService> logger, IHostApplicationLifetime appLifetime, ISampleService sampleService)
        {
            _logger = logger;
            _sampleService = sampleService;
            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);
            appLifetime.ApplicationStopped.Register(OnStopped);
        }

        Task IHostedLifecycleService.StartingAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("1. StartingAsync has been called.");

            return Task.CompletedTask;
        }

        Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("2. StartAsync has been called.");

            return Task.CompletedTask;
        }

        Task IHostedLifecycleService.StartedAsync(CancellationToken cancellationToken)
        {
           

            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            _logger.LogInformation("4. OnStarted has been called.");
            _sampleService.SayHellow();
        }

        private void OnStopping()
        {
            _logger.LogInformation("5. OnStopping has been called.");
        }

        Task IHostedLifecycleService.StoppingAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("6. StoppingAsync has been called.");

            return Task.CompletedTask;
        }

        Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("7. StopAsync has been called.");

            return Task.CompletedTask;
        }

        Task IHostedLifecycleService.StoppedAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("8. StoppedAsync has been called.");

            return Task.CompletedTask;
        }

        private void OnStopped()
        {
            _logger.LogInformation("9. OnStopped has been called.");
        }
    }
    public class StartupSolution
    {
        private readonly ISampleService _sampleService;
        public StartupSolution(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }
        public void Start()
        {
            _sampleService.SayHellow();
        }
    }

}