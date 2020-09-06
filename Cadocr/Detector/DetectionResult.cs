namespace Cadocr.Detector
{
    public class DetectionResult
    {
        public string Text { get; }

        public DetectionResult(string text)
        {
            Text = text;
        }
    }
}
