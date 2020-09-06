using System.Threading.Tasks;
using Cadocr.Receiver;

namespace Cadocr.Sender
{
    public interface ISender
    {
        Task SendAsync(Message message, IContext context);
    }
}
