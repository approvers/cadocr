using System.Threading.Tasks;

namespace Cadocr.Receiver
{
    public interface IReceiver
    {
        Task StartAsync();
    }
}
