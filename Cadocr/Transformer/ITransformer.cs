using System.Threading.Tasks;
using Cadocr.Detector;
using Cadocr.Receiver;
using Cadocr.Sender;

namespace Cadocr.Transformer
{
    public interface ITransformer
    {
        Task<Message> TransformAsync(DetectionResult result, IContext context);
    }
}
