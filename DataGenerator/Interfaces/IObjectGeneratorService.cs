using DataGenerator.Models;
using System.Threading;
using System.Threading.Tasks;

namespace DataGenerator.Interfaces
{
    public interface IObjectGeneratorService
    {
        Task<Database> Convert(string json, CancellationToken cancellationToken);
    }
}
