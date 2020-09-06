using Cadocr.Detector.CloudVision;
using Cadocr.Receiver.Discord;
using Cadocr.Sender.Discord;
using Cadocr.Transformer.Default;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cadocr
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IHostEnvironment environment)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDiscordReceiver(Configuration)
                .AddDiscordSender()
                .AddCloudVisionDetector(Configuration)
                .AddDefaultTransformer()
                .AddTransient<Bus>()
                .AddHostedService<Worker>();
        }
    }
}
