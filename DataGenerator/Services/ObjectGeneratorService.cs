using DataGenerator.Interfaces;
using DataGenerator.Models;
using DataGenerator.Models.Extensions;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DataGenerator.Services
{
    public class ObjectGeneratorService : IObjectGeneratorService
    {
        public async Task<Database> Convert(string json, CancellationToken cancellationToken)
        {
            var database = new Database();

            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true
            };

            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            using(var stream = new MemoryStream(byteArray))
            {
                database = await JsonSerializer.DeserializeAsync<Database>(stream, options, cancellationToken);
            }

            return database.DetermineDependencyOrder();
        }
    }
}
