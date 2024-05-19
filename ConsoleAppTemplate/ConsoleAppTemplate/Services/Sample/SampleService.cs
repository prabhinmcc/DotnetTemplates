using ConsoleAppTemplate.Resources;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTemplate.Services.Sample
{
    public class SampleService : ISampleService
    {
        private readonly ApplicationConfiguration _applicationConfiguration;
        private readonly ILogger _logger;

        public SampleService(ApplicationConfiguration applicationConfiguration, ILogger<ISampleService> logger)
        {
            _applicationConfiguration = applicationConfiguration;
            _logger = logger;
        }
        public void SayHellow()
        {
            _logger.LogInformation(_applicationConfiguration.GeneralConfiguration.ApplicationName);


        }
    }
}
