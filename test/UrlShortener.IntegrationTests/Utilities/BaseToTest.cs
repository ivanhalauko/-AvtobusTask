using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace UrlShortener.IntegrationTests.Utilities
{
    public class BaseToTest
    {
        private readonly string _dbConnectionString;

        public BaseToTest()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string pathToAppSettingsJson = Path.GetFullPath(Path.Combine(path, "..\\..\\..\\", "appsettings.json"));
            var configs = new ConfigurationBuilder().AddJsonFile(pathToAppSettingsJson).Build();
            _dbConnectionString = configs["DbConnectionString:Database"];
        }

        public string DbConnString => _dbConnectionString;
    }
}
