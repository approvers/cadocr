namespace Cadocr.Detector
{
    public class DetectionRequest
    {
        public string ImageUri { get; }

        public DetectionRequest(string imageUri)
        {
            ImageUri = imageUri;
        }
    }
}
