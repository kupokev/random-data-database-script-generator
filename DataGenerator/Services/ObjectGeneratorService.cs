using DataGenerator.Interfaces;
using DataGenerator.Models;
using System;
using System.Collections.Generic;
using System.Json;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Services
{
    public class ObjectGeneratorService : IObjectGeneratorService
    {
        public async Task<DatabaseDto> Convert(JsonValue json)
        {
            var database = new DatabaseDto();

            if (json.ContainsKey("database"))
            {
                string b = json["database"]; 

                // Get database name 
            }

            return await Task.FromResult(database);
        }
    }
}
