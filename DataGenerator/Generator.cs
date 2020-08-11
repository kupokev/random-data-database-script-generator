using DataGenerator.Interfaces;
using System;
using System.Json;
using System.Threading.Tasks;

namespace DataGenerator
{
    public class Generator : IDataGenerator
    {
        private readonly IObjectGeneratorService _objectGeneratorService;

        public Generator(IObjectGeneratorService objectGeneratorService)
        {
            _objectGeneratorService = objectGeneratorService;
        }

        public async Task<string> GenerateSQL(string json)
        {
            try
            {
                JsonValue jsonp = JsonValue.Parse(json);
            }
            catch
            {
                throw new Exception("There was an issues parsing the provided JSON");
            }

            var script = "";

            try
            {


                return script;
            }
            catch
            {
                throw new Exception("There was an issues parsing the provided JSON");
            }
        }
    }
}
