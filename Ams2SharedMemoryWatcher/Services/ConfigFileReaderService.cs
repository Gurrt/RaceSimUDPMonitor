using Ams2SharedMemoryWatcher.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams2SharedMemoryWatcher.Services
{
    internal class ConfigFileReaderService
    {
        private static readonly string CONFIG_FILE_NAME = "config.json";
        private readonly IConfiguration configuration;
        public ConfigFileReaderService()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(basePath, CONFIG_FILE_NAME), optional: false);

            configuration = configurationBuilder.Build();
        }

        public SharedMemoryWatcherConfiguration GetConfiguration()
        {
            SharedMemoryWatcherConfiguration configObj = new();
            ConfigurationBinder.Bind(configuration, configObj);
            return configObj;
        }
    }
}
