using DataGenerator.Interfaces;
using DataGenerator.Models;
using System;

namespace DataGenerator.Services
{
    public class DataGeneratorService : IDataGeneratorService
    {
        private readonly IDatabaseGeneratorService _databaseGenerator;

        public DataGeneratorService(IDatabaseGeneratorService databaseGenerator)
        {
            _databaseGenerator = databaseGenerator;
        }

        public string GenerateScript(Database database)
        {
            var script = "";

            //Traverse dbo to get all the tables
            foreach (var table in database.tables)
            {
                // Populate table with data
                table.Rows = PopulateTable(table);
                
                // Add object to the script

            }

            return script;
        }

        private DataRow[] PopulateTable(Table table)
        {
            var values = new DataRow[table.recordCount];

            // Build data rows
            dynamic row = new DataRow();

            foreach (var column in table.columns)
            {
                switch(column.data_type)
                {
                    case "bigint":
                        row.AddProperty(column.name, column.IsNullable ? (Int64?)null : (Int64)0);
                        break;

                    case "char":
                    case "varchar":
                    case "nchar":
                    case "nvarchar":
                        row.AddProperty(column.name, "");
                        break;
                }
            }

            for (int i = 0; i < table.recordCount; i++)
            {
                values[i] = row;
            }

            // Populate Data in rows
            foreach (var column in table.columns)
            {

            }

            return values;
        }
    }
}
