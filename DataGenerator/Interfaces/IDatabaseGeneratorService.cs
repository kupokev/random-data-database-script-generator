using DataGenerator.Models;

namespace DataGenerator.Interfaces
{
    public interface IDatabaseGeneratorService
    {
        //object GenerateObject(Database database);

        string GenerateScript(Database database);
    }
}
