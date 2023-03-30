using Microsoft.Extensions.Configuration;

namespace EFCoreSample.src
{
    internal static class AppConfiguration
    {
        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            return builder.Build();
        }

    }
}
