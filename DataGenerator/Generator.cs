using DataGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Json;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    public class Generator
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


            return "";
        }
    }
}
