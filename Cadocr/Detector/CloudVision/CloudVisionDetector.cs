using System.Threading.Tasks;
using Google.Cloud.Vision.V1;

namespace Cadocr.Detector.CloudVision
{
    public class CloudVisionDetector : IDetector
    {
        private readonly ImageAnnotatorClient _client;

        public CloudVisionDetector(ImageAnnotatorClient client)
        {
            _client = client;
        }

        public async Task<DetectionResult> DetectAsync(DetectionRequest request)
        {
            var image = Image.FromUri(request.ImageUri);
            var annotation = await _client.DetectDocumentTextAsync(image);

            return new DetectionResult(annotation.Text);
        }
    }
}
