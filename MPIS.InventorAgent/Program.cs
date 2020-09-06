using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MPIS.InventorAgent.Configuration;
using MPIS.InventorAgent.Logic;
using MPIS.InventorAgent.Model;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace MPIS.InventorAgent
{
    class Program
    {

        

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ServiceCollection serviceCollection = new ServiceCollection();
            Conf.ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            /*var builder = new ConfigurationBuilder()
            .AddJsonFile($"settings.json", true, true)
            //.AddJsonFile($"appsettings.{environmentName}.json", true, true)
            .AddEnvironmentVariables();
            var configuration = builder.Build();*/
            //var myConnString = Conf.Configuration.GetSection("AzureFunction").Value;


            CompleteDevice dev = null;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                dev = CompleteDeviceInfo.GetCompleteInfo();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {

            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) { 
            
            }

            WaitToHaveInternet();


            string jsonString = JsonConvert.SerializeObject(dev);
            File.WriteAllTextAsync("result.json",jsonString,Encoding.UTF8);
            //Console.WriteLine(jsonString);
            
        }

        public static void WaitToHaveInternet() {
            do
            {

            } while (!CheckForInternetConnection());
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        
    }


}
