using System;

namespace DataGenerator.Models.Extensions
{
    public static class ColumnExtension
    {
        public static string GenerateSQL(this Column column, bool isLast)
        {
            try
            {
                // Column Name
                var script = string.Format("\t[{0}] ", column.name.Trim());

                // Column Type
                if (column.identity)
                {
                    // Max precision according to Microsoft documentation is 38
                    if (column.scale > column.precision || column.precision == 0 || column.precision > 38)
                    {
                        script += "INT IDENTITY(1, 1) ";
                    }
                    else
                    {
                        script += string.Format("INT IDENTITY({0}, {1}) ", column.precision, column.scale);
                    }
                }
                else
                {
                    switch (column.data_type.ToLower())
                    {
                        case "bigint":
                        case "bit":
                        case "date":
                        case "datetime":
                        case "float":
                        case "int":
                        case "smallint":
                        case "tinyint":
                        case "uniqueidentifier":
                            script += string.Format("{0} ",
                                column.data_type
                                );

                            break;

                        case "char":
                        case "varchar":
                        case "nchar":
                        case "nvarchar":
                            script += string.Format("[{0}]({1}) ",
                                column.data_type,
                                column.nSize
                                );

                            break;

                        case "decimal":
                        case "numeric":
                            script += string.Format("[{0}]({1}, {2}) ",
                                column.data_type,
                                column.Precision,
                                column.Scale
                                );

                            break;

                        default:
                            break;
                    }
                }

                // Nullable
                script += column.IsNullable ? "NULL" : "NOT NULL";

                // Ending ,
                if (!isLast) script += @",";

                return script + Environment.NewLine;
            }
            catch
            {
                return "";
            }
        }
    }
}
