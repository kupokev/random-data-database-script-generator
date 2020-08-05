using System.Collections.Generic;

namespace DataGenerator.Models
{
    public class TableDto
    {
        public TableDto()
        {
            Columns = new List<ColumnDto>();
        }

        public string Name { get; set; }

        public string Schema { get; set; }

        public List<ColumnDto> Columns { get; set; }
    }
}
