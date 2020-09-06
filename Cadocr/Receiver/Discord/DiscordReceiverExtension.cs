using System;
using System.Threading;
using System.Threading.Tasks;
using Cadocr.Receiver.Discord.EventHandler;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cadocr.Receiver.Discord
{
    public static class DiscordReceiverExtension
    {
        public static IServiceCollection AddDiscordReceiver(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddTransient<MessageReceivedEventHandler>()
                .AddSingleton(provider => new Lazy<Task<IDiscordClient>>(async () =>
                {
                    var client = new DiscordSocketClient();

                    client.MessageReceived += provider.GetService<MessageReceivedEventHandler>().HandleAsync;
                    client.Disconnected += e =>
                    {
                        Console.WriteLine(e);
                        return Task.CompletedTask;
                    };
                    
                    await client.LoginAsync(TokenType.Bot, config["Discord:Bot:Token"]);

                    return client;
                }, LazyThreadSafetyMode.PublicationOnly))
                .AddTransient<IReceiver, DiscordReceiver>();
        }
    }
}
