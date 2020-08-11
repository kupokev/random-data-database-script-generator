using DataGenerator.Interfaces;
using RDSGConsole.Interfaces;
using System.Threading.Tasks;

namespace RDSGConsole.Services
{
    public class MainService : IMainService
    {
        private readonly ITemplateService _templateService;
        private readonly IDataGenerator _dataGenerator;

        public MainService(ITemplateService templateService, IDataGenerator dataGenerator)
        {
            _templateService = templateService;
            _dataGenerator = dataGenerator;
        }

        public async Task Start()
        {
            var json = await _templateService.GetJSON(@"F:\Repositories\My Projects\random-data-database-script-generator", @"manufacturing_template.json");

            var script = await _dataGenerator.GenerateSQL(json);

            // Dump script to file
        }
    }
}
