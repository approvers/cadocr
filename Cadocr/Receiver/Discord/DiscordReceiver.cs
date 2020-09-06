using System;
using System.Threading.Tasks;
using Discord;

namespace Cadocr.Receiver.Discord
{
    public class DiscordReceiver : IReceiver
    {
        private readonly Lazy<Task<IDiscordClient>> _clientTaskLazy;

        public DiscordReceiver(Lazy<Task<IDiscordClient>> clientTaskLazy)
        {
            _clientTaskLazy = clientTaskLazy;
        }
        
        public async Task StartAsync()
        {
            var client = await _clientTaskLazy.Value;
            await client.StartAsync();
        }
    }
}
