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

            foreach (var table in database.tables)
            {
                script += CreateTableScript(table) + Environment.NewLine;
            }

            return script;
        }

        private string CreateTableScript(Table table)
        {
            if (string.IsNullOrWhiteSpace(table?.name)) throw new Exception("Table name not declared");

            var script = table.GenerateHeaderSQL();

            var colCount = 1;

            foreach (var column in table.columns)
            {
                script += column.GenerateSQL(colCount++ == table.columns.Count() ? true : false);
            }

            script += table.GenerateFooterSQL();

            return script;
        }

        public object GenerateObject(Database database)
        {
            // TO DO: Convert the database object into an object
            // https://docs.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject?view=netcore-3.1

            return new object();
        }
    }
}
