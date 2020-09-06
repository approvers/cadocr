using Discord;
using Discord.WebSocket;

namespace Cadocr.Receiver.Discord
{
    public class DiscordContext : IContext
    {
        public bool IsDryRun { get; }
        public IUser Me { get; }
        public IMessage Message { get; }
        public ISocketMessageChannel Channel { get; }

        public DiscordContext(bool isDryRun, IUser me, IMessage message, ISocketMessageChannel channel)
        {
            IsDryRun = isDryRun;
            Me = me;
            Message = message;
            Channel = channel;
        }
    }
}
