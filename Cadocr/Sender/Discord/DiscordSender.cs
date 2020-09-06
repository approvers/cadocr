using System;
using System.Threading.Tasks;
using Cadocr.Receiver;
using Cadocr.Receiver.Discord;

namespace Cadocr.Sender.Discord
{
    public class DiscordSender : ISender
    {
        public async Task SendAsync(Message message, IContext context)
        {
            if (!(context is DiscordContext ctx))
            {
                throw new Exception("Context not supported.");
            }

            await ctx.Message.RemoveReactionAsync(Emojis.Waiting, ctx.Me);
            await ctx.Message.AddReactionAsync(Emojis.Succeeded);
            await ctx.Channel.SendMessageAsync(message.Text);
        }
    }
}
