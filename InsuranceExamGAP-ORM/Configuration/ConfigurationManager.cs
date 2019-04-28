using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace InsuranceExamGAP_ORM.Configuration
{
    public class ConfigurationManager 
    {
        public static IConfiguration Configuration { get; }
        static ConfigurationManager()
        {
            var launchSettings = JObject.Parse(File.ReadAllText(
                Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()), "InsuranceExamGAP", "Properties", "launchSettings.json")));
            var environment = launchSettings["profiles"]["InsuranceExamGAP"]["environmentVariables"]["ASPNETCORE_ENVIRONMENT"];
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()), "InsuranceExamGAP"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();
        }
    }
}
