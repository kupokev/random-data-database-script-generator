using DataGenerator.Interfaces;
using DataGenerator.Models;

namespace DataGenerator.Services
{
    public class DataGeneratorService : IDataGeneratorService
    {
        private readonly IDatabaseGeneratorService _databaseGenerator;

        public DataGeneratorService(IDatabaseGeneratorService databaseGenerator)
        {
            _databaseGenerator = databaseGenerator;
        }

        public string GenerateScript(Database database)
        {
            var dbo = _databaseGenerator.GenerateObject(database);

            var script = "";

            // Traverse dbo to get all the tables
            //foreach(var table in dbo)
            //{

            //}

            return script;
        }
    }
}
