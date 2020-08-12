namespace DataGenerator.Models
{
    public class Column
    {
        public string name { get; set; }

        public string type { get; set; }

        public bool nullable { get; set; }

        public bool identity { get; set; }

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
