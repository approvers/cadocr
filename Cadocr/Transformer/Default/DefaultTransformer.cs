using System.Linq;
using System.Threading.Tasks;
using Cadocr.Detector;
using Cadocr.Receiver;
using Cadocr.Sender;

namespace Cadocr.Transformer.Default
{
    public class DefaultTransformer : ITransformer
    {
        public Task<Message> TransformAsync(DetectionResult result, IContext context)
        {
            var lines = result.Text.Split('\n');

            return Task.FromResult(
                new Message(
                    string.Format(
                        context.IsDryRun ? "Meigen by {0}:\n{1}": "g!meigen make {0} {1}",
                        lines.First().Split(' ').FirstOrDefault(),
                        string.Join('\n', lines.Skip(1))
                    )
                )
            );
        }
    }
}
