using System.Threading.Tasks;

namespace RDSGConsole.Interfaces
{
    public interface ITemplateService
    {
        Task<string> GetJSON(string path, string filename);
    }
}
