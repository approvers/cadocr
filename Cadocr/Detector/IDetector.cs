using System.Threading.Tasks;

namespace Cadocr.Detector
{
    public interface IDetector
    {
        Task<DetectionResult> DetectAsync(DetectionRequest request);
    }
}
