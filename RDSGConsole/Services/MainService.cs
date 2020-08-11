using DataGenerator.Interfaces;
using RDSGConsole.Interfaces;
using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RDSGConsole.Services
{
    public class MainService : IMainService
    {
        private readonly IDataGenerator _dataGenerator;

        public MainService(IDataGenerator dataGenerator)
        {
            _dataGenerator = dataGenerator;
        }

        public async Task Start(CancellationToken cancellationToken)
        {
            var script = "";

            var json = GetJSON(@"F:\Repositories\My Projects\random-data-database-script-generator", @"manufacturing_template.json", cancellationToken);

            script = await _dataGenerator.GenerateSQL(json, cancellationToken);
            
            System.Console.WriteLine(script);

            // Dump script to file
        }

        public string GetJSON(string path, string filename, CancellationToken cancellationToken)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    var file = Path.Combine(path, filename);

                    if (File.Exists(file))
                    {
                        var options = new JsonSerializerOptions
                        {
                            IgnoreNullValues = true
                        };

                        return File.ReadAllText(file);
                    }
                    else
                    {
                        throw new Exception("File doesn't exist");
                    }
                }
                else
                {
                    throw new Exception("Path doesn't exist");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }
            
        }
    }
}
