using DataGenerator.Models;

namespace DataGenerator.Interfaces
{
    public interface IDatabaseGeneratorService
    {
        string GenerateScript(Database database);
    }
}
