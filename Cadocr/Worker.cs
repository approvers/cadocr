using System.Threading;
using System.Threading.Tasks;
using Cadocr.Receiver;
using Microsoft.Extensions.Hosting;

namespace Cadocr
{
    public class Worker : BackgroundService
    {
        private readonly IReceiver _receiver;

        public Worker(IReceiver receiver)
        {
            _receiver = receiver;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _receiver.StartAsync();
            await Task.Delay(-1, stoppingToken);
        }
    }
}
