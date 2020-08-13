using DataGenerator.Interfaces;
using DataGenerator.Models;
using DataGenerator.Models.Extensions;
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
                script += column.GenerateSQL(colCount++ == table.columns.Count() ? true : false);
            }

            script += ");" + Environment.NewLine;

            return script;
        }
    }
}
