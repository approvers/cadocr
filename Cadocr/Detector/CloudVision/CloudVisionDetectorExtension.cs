using System.IO;
using Google.Cloud.Vision.V1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cadocr.Detector.CloudVision
{
    public static class CloudVisionDetectorExtension
    {
        public static IServiceCollection AddCloudVisionDetector(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddTransient(_ =>
                    new ImageAnnotatorClientBuilder
                    {
                        JsonCredentials = File.ReadAllText(config["CloudVision:Credentials:Path"])
                    }
                        .Build()
                )
                .AddTransient<IDetector, CloudVisionDetector>();
        }
    }
}
