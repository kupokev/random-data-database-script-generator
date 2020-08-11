using DataGenerator.Interfaces;
using DataGenerator.Models;
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
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true
            };

            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            using(var stream = new MemoryStream(byteArray))
            {
                return await JsonSerializer.DeserializeAsync<Database>(stream, options, cancellationToken);
            }
        }
    }
}
