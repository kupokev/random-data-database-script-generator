using System.Threading;
using System.Threading.Tasks;

namespace RDSGConsole.Interfaces
{
    public interface IMainService
    {
        Task Start(CancellationToken cancellationToken);
    }
}
