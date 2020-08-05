using System.Collections.Generic;

namespace DataGenerator.Models
{
    public class DatabaseDto
    {
        public DatabaseDto()
        {
            Tables = new List<TableDto>();
        }

        public string Name { get; set; }

        public List<TableDto> Tables { get; set; }
    }
}
