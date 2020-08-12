using DataGenerator.Interfaces;
using DataGenerator.Models;
using System;
using System.Linq;

namespace DataGenerator.Services
{
    public class DatabaseGeneratorService : IDatabaseGeneratorService
    {
        public string GenerateScript(Database database)
        {
            var script = "";

            if (!string.IsNullOrWhiteSpace(database?.name))
            {
                script += string.Format("USE [{0}]{1}", database.name, Environment.NewLine);
                script += string.Format("GO{0}", Environment.NewLine);
                script += Environment.NewLine;
            }

            foreach (var table in database.tables.OrderBy(x => x.DependencyOrder))
            {
                script += CreateTableScript(table) + Environment.NewLine;
            }

            return script;
        }

        private string CreateTableScript(Table table)
        {
            if (string.IsNullOrWhiteSpace(table?.name)) throw new Exception("Table name not declared");

            var script = string.Format(
                "CREATE TABLE [{0}].[{1}] ({2}",
                string.IsNullOrWhiteSpace(table?.schema) ? "dbo" : table.schema.Trim()
                , table.name
                , Environment.NewLine
                );

            var colCount = 1;

            foreach (var column in table.columns)
            {
                script += CreateColumnScript(column, colCount++ == table.columns.Count() ? true : false);
            }

            script += ");" + Environment.NewLine;

            return script;
        }

        private string CreateColumnScript(Column column, bool isLast)
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
                    switch (column.type.ToLower())
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
                                column.type
                                );

                            break;

                        case "char":
                        case "varchar":
                        case "nchar":
                        case "nvarchar":
                            script += string.Format("[{0}]({1}) ",
                                column.type,
                                column.size < 1 ? "1" : column.size > 4000 ? "MAX" : column.size.ToString()
                                );

                            break;

                        case "decimal":
                        case "numeric":
                            script += string.Format("[{0}]({1}, {2}) ",
                                column.type,
                                column.precision < 1 ? 1 : column.precision > 38 ? 38 : column.precision,
                                column.scale < 1 ? 1 : column.scale > 38 ? 38 : column.scale > column.precision ? column.precision : column.scale
                                );

                            break;

                        default:
                            break;
                    }
                }

                // Nullable
                script += column.identity || !column.nullable ? "NOT NULL" : "NULL";

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
