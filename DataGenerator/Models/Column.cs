using System.Collections;
using System.Text.Json.Serialization;

namespace DataGenerator.Models
{
    public class Column
    {
        public Column()
        {
            nullable = true; //default to true
        }

        public string name { get; set; }

        public string data_type { get; set; }

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

        [JsonIgnore]
        public bool IsNullable
        {
            get
            {
                return identity || !nullable ? false : true;
            }
        }

        [JsonIgnore]
        public int Precision
        {
            get
            {
                if (data_type.ToLower() == "decimal" || data_type.ToLower() == "numeric")
                {
                    return precision < 1 ? 1 : precision > 38 ? 38 : precision;
                }
                else
                {
                    return 0;
                }
            }
        }

        [JsonIgnore]
        public int Scale
        {
            get
            {
                if (data_type.ToLower() == "decimal" || data_type.ToLower() == "numeric")
                {
                    return scale < 1 ? 1 : scale > 38 ? 38 : scale > Precision ? Precision : scale;
                }
                else
                {
                    return 0;
                }
            }
        }

        [JsonIgnore]
        public string nSize
        {
            get
            {
                switch (data_type.ToLower())
                {
                    case "char":
                    case "varchar":
                        return size < 1 ? "1" : size > 2000 ? "MAX" : size.ToString();

                    case "nchar":
                    case "nvarchar":
                        return size < 1 ? "1" : size > 4000 ? "MAX" : size.ToString();

                    default:
                        return "0";
                }
            }
        }
    }
}
