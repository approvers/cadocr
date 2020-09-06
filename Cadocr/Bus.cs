using System.Threading.Tasks;
using Cadocr.Detector;
using Cadocr.Receiver;
using Cadocr.Sender;
using Cadocr.Transformer;

namespace Cadocr
{
    public class Bus
    {
        private readonly IDetector _detector;
        private readonly ITransformer _transformer;
        private readonly ISender _sender;
        
        public Bus(IDetector detector, ITransformer transformer, ISender sender)
        {
            _detector = detector;
            _transformer = transformer;
            _sender = sender;
        }

        public async Task DispatchAsync(DetectionRequest request, IContext context)
        {
            await _sender.SendAsync(
                await _transformer.TransformAsync(
                    await _detector.DetectAsync(request),
                    context
                ),
                context
            );
        }
    }
}
