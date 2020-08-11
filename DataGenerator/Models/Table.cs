using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public int DependencyOrder { get; set; }

        public List<Column> columns { get; set; }
    }
}
