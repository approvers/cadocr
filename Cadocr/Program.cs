using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Cadocr
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    new Startup(hostContext.HostingEnvironment).ConfigureServices(services);
                });
        }
    }
}
