using DataGenerator.Interfaces;
using DataGenerator.Models;
using System;
using System.Collections.Generic;
using System.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataGenerator.Services
{
    public class ObjectGeneratorService : IObjectGeneratorService
    {
        public async Task<Database> Convert(JsonValue json, CancellationToken cancellationToken)
        {
            var database = new Database();

            if (json.ContainsKey("database"))
            {
                string b = json["database"]; 

                // Get database name 
            }

            return await Task.FromResult(database);
        }
    }
}
