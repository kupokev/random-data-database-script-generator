using System;

namespace DataGenerator.Models.Extensions
{
    public static class TableExtension
    {
        public static string GenerateFooterSQL(this Table table)
        {
            return string.Format(@");{0}", Environment.NewLine);
        }

        public static string GenerateHeaderSQL(this Table table)
        {
            return string.Format(
                "CREATE TABLE [{0}].[{1}] ({2}",
                table.Schema
                , table.name
                , Environment.NewLine
                );
        }
    }
}