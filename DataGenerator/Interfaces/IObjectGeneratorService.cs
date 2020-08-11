using DataGenerator.Models;
using System.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DataGenerator.Interfaces
{
    public interface IObjectGeneratorService
    {
        Task<Database> Convert(JsonValue json, CancellationToken cancellationToken);
    }
}
