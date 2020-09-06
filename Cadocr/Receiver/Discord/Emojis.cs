using Discord;

namespace Cadocr.Receiver.Discord
{
    public static class Emojis
    {
        public static IEmote Waiting => new Emoji("⏳");
        public static IEmote Succeeded => new Emoji("☑");
    }
}
