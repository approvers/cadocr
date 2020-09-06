using Microsoft.Extensions.DependencyInjection;

namespace Cadocr.Transformer.Default
{
    public static class DefaultTransformerExtension
    {
        public static IServiceCollection AddDefaultTransformer(this IServiceCollection services)
        {
            return services.AddTransient<ITransformer, DefaultTransformer>();
        }
    }
}
