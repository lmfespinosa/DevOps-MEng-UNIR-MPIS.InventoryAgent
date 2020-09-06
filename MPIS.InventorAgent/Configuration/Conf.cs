#region "Libraries"

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

#endregion

namespace MPIS.InventorAgent.Configuration
{
    public static class Conf
    {
        public static IConfigurationRoot Configuration;

        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Add logging
            /*serviceCollection.AddSingleton(LoggerFactory.Create(builder =>
            {
                builder
                    .AddSerilog(dispose: true);
            }));

            serviceCollection.AddLogging();*/

            // Build configuration
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("settings.json", false)
                .AddEnvironmentVariables()
                .Build();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(Configuration);

            // Add app
            //serviceCollection.AddTransient<App>();
        }

    }
}
