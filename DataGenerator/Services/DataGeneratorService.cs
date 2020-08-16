using DataGenerator.Interfaces;
using DataGenerator.Models;
using System.Collections.Generic;
using System.Dynamic;

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
            //var dbo = _databaseGenerator.GenerateObject(database);

            var script = "";

            //Traverse dbo to get all the tables
            foreach (var table in database.tables)
            {
                var dbo = new DynamicTable();

                foreach (var column in table.columns)
                {
                    dbo.Add(column.name, PopulateColumn(column, table.recordCount));
                }

                // Add object to the script


            }

            return script;
        }

        private List<object> PopulateColumn(Column column, int records)
        {
            var values = new List<object>();

            for (int i = 0; i < records; i++)
            {
                values.Add(1);
            }

            return values;
        }

        private class DynamicTable : DynamicObject
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject?view=netcore-3.1

            // The inner dictionary.
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            // This property returns the number of elements
            // in the inner dictionary.
            public int Count
            {
                get
                {
                    return dictionary.Count;
                }
            }

            // If you try to get a value of a property
            // not defined in the class, this method is called.
            public override bool TryGetMember(
                GetMemberBinder binder, out object result)
            {
                // Converting the property name to lowercase
                // so that property names become case-insensitive.
                string name = binder.Name.ToLower();

                // If the property name is found in a dictionary,
                // set the result parameter to the property value and return true.
                // Otherwise, return false.
                return dictionary.TryGetValue(name, out result);
            }

            // If you try to set a value of a property that is
            // not defined in the class, this method is called.
            public override bool TrySetMember(
                SetMemberBinder binder, object value)
            {
                // Converting the property name to lowercase
                // so that property names become case-insensitive.
                dictionary[binder.Name.ToLower()] = value;

                // You can always add a value to a dictionary,
                // so this method always returns true.
                return true;
            }

            public void Add(string name, object value)
            {
                dictionary[name.ToLower()] = value;
            }
        }
    }
}
