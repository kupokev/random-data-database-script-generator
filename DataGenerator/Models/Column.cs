using System.Collections;

namespace DataGenerator.Models
{
    public class Column
    {
        public Column()
        {
            nullable = true; //default to true
        }

        public string name { get; set; }

        public string type { get; set; }

        public bool nullable { get; set; }

        public bool identity { get; set; }

        public BitArray contiguous { get; set; }

        // No idea how this is going to work currently
        public string pattern { get; set; }

        public int min { get; set; }

        public int max { get; set; }

        // numeric and decimal precision
        public int precision { get; set; }

        // numeric and decimal scale
        public int scale { get; set; }

        // to be used with varhcar and nchar
        public int size { get; set; }

        public string generateFromTable { get; set; }

        public string generateFromColumn { get; set; }
    }
}
