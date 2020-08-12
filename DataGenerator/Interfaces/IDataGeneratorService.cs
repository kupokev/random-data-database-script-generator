using DataGenerator.Models;

namespace DataGenerator.Interfaces
{
    public interface IDataGeneratorService
    {
        string GenerateScript(Database database);
    }
}
