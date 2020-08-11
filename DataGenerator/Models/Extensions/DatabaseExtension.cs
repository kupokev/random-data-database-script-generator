namespace DataGenerator.Models.Extensions
{
    public static class DatabaseExtension
    {

        /// <summary>
        /// Determines the order the tables are generated in the script based on dependencies to each other.
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public static Database DetermineDependencyOrder(this Database database)
        {
            // Determine if there is a circular dependency and throw an error if so.

            // Arrange tables by dependency order so they get generated in proper order.

            return database;
        }
    }
}
