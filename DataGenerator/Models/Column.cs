namespace DataGenerator.Models
{
    public class Column
    {
        public string name { get; set; }

        public string type { get; set; }

        public bool nullable { get; set; }

        public bool identity { get; set; }

        public string generateFromTable { get; set; }

        public string generateFromColumn { get; set; }
    }
}
