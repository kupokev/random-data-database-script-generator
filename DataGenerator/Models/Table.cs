using System.Collections.Generic;

namespace DataGenerator.Models
{
    public class Table
    {
        public Table()
        {
            columns = new List<Column>();
        }

        public string name { get; set; }

        public string schema { get; set; }

        public int recordCount { get; set; }

        public List<Column> columns { get; set; }
    }
}
