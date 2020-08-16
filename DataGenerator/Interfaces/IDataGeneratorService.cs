using DataGenerator.Models;
using System.Collections.Generic;

namespace DataGenerator.Interfaces
{
    public interface IDataGeneratorService
    {
        string GenerateScript(Database database);
    }
}
