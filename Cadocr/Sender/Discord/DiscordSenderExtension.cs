using Microsoft.Extensions.DependencyInjection;

namespace Cadocr.Sender.Discord
{
    public static class DiscordSenderExtension
    {
        public static IServiceCollection AddDiscordSender(this IServiceCollection services)
        {
            return services.AddTransient<ISender, DiscordSender>();
        }
    }
}
