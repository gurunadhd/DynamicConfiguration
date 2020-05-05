using Microsoft.Extensions.Configuration;
using System;

namespace DynamicConfiguration
{
    class Program
    {

        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("AppSettings.json")
                .Build();
            return config;
        }


        static void Main(string[] args)
        {
            IConfiguration Config = Program.InitConfiguration();
            //Getting config values from JSON configuration file
            Console.WriteLine(Config["Environments:Dev:Key"]);

            //Getting dynamic config values from JSON configuration file based on Current_ApplicationSettings key, 
            //Which is currently set to Test environment
            Console.WriteLine(Config[$"Environments:{Config["ApplicationSettings:Current_ApplicationSettings"]}:Key"]);
        }
    }
}
