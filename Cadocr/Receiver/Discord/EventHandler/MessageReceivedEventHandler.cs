using System;
using System.Linq;
using System.Threading.Tasks;
using Cadocr.Detector;
using Discord;
using Discord.WebSocket;

namespace Cadocr.Receiver.Discord.EventHandler
{
    public class MessageReceivedEventHandler
    {
        private readonly Lazy<Task<IDiscordClient>> _clientTaskLazy;
        private readonly Bus _bus;
        
        public MessageReceivedEventHandler(Lazy<Task<IDiscordClient>> clientTaskLazy, Bus bus)
        {
            _clientTaskLazy = clientTaskLazy;
            _bus = bus;
        }
        
        public async Task HandleAsync(SocketMessage message)
        {
            if (message.Author.IsBot) return;
            if (message.Content.ToUpper() != "CAD") return;
            if (message.Attachments.Count < 1) return;

            var client = await _clientTaskLazy.Value;
            var isDryRun = message.Content.ToUpper() != message.Content;

            await message.AddReactionAsync(new Emoji("⏳"));
            await _bus.DispatchAsync(
                new DetectionRequest(message.Attachments.First().Url),
                new DiscordContext(isDryRun, client.CurrentUser, message, message.Channel)
            );
        }
    }
}
