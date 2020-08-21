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

        private object[,] PopulateTable(Table table)
        {
            // Array of values
            var values = new object[table.recordCount + 1, table.columns.Count];

            // Add column Headers (Row 0)
            for (int i = 0; i < table.columns.Count; i++)
            {
                values[0, i] = table.columns[i].name;
            }

            // Add row data (Start Row 1)
            for (int i = 1; i <= table.recordCount; i++)
            {
                for (int j = 0; j < table.columns.Count; j++)
                {
                    switch (table.columns[j].data_type)
                    {
                        case "bigint":
                            values[i, j] = table.columns[j].IsNullable ? (Int64?)null : (Int64)0;
                            break;

                        case "bit":
                            values[i, j] = table.columns[j].IsNullable ? (bool?)null : false;
                            break;

                        case "char":
                        case "varchar":
                        case "nchar":
                        case "nvarchar":
                            values[i, j] = table.columns[j].IsNullable ? null : "";
                            break;

                        case "date":
                        case "datetime":
                        case "datetime2":
                            values[i, j] = table.columns[j].IsNullable ? (DateTime?)null : DateTime.Parse("1900-01-01");
                            break;

                        case "decimal":
                        case "money":
                        case "numeric":
                        case "smallmoney":
                            values[i, j] = table.columns[j].IsNullable ? (decimal?)null : (decimal)0;
                            break;

                        case "float":
                            values[i, j] = table.columns[j].IsNullable ? (double?)null : (double)0;
                            break;

                        case "int":
                            // If IDENTITY, set the column data
                            values[i, j] = table.columns[j].IsNullable ? (int?)null : table.columns[j].identity ? (int)i : (int)0;
                            break;

                        default:
                            throw new Exception(string.Format("{0} is an unsupported data type", table.columns[j].data_type));
                    }
                }
            }

            var value = 15;

            if (values[1, 0].GetType() == value.GetType())
            {
                values[1, 0] = value;
            }
            else
            {
                Console.WriteLine("failed");
            }


            // Populate Data in rows
            for (int i = 0; i < table.columns.Count; i++)
            {
                // populate array (Eventually data generation method)
                var generatedData = new object[table.recordCount];

                for (int j = 0; j < table.recordCount; j++)
                {
                    values[j + 1, i] = generatedData[j];
                }
            }

            table.Rows = values;

            return values;
        }
    }
}
