using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;

namespace CaseManagement.API
{
    public class Program
    {
        private static string env = "";
        public static void Main(string[] args)
        {
            //UtilityLibrary.Utility.CreateDocumnetFolder();
            NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                //To read appsetting json for Environment - Dev stands for development
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var envResult = config.GetSection("Env").GetSection("Env").Value;

                if (envResult == ".Development")
                {
                    env = envResult;
                    config = new ConfigurationBuilder().AddJsonFile($"appsettings{env}.json").Build();
                    logger = NLog.Web.NLogBuilder.ConfigureNLog("nlogDev.config").GetCurrentClassLogger();
                }
                logger.Debug("init main");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((a, config) =>
               {
                   config.AddJsonFile($"appsettings{env}.json");
               })
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               }).ConfigureLogging(logging =>
               {
                   logging.ClearProviders();
                   logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
               }).UseNLog();  // NLog: Setup NLog for Dependency injection
    }
}
