using System.Collections.Generic;

namespace DataGenerator.Models
{
    public class Database
    {
        public Database()
        {
            tables = new List<Table>();
        }

        public string name { get; set; }

        public List<Table> tables { get; set; }
    }
}
