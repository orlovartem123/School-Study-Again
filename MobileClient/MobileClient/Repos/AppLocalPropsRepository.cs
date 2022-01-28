using MobileClient.Models.SqlLite;
using SQLite;

namespace MobileClient.Repos
{
    public class AppLocalPropsRepository
    {
        SQLiteConnection database;

        public AppLocalPropsRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<AppLocalProps>();
        }

        public void InitDb()
        {
            if (GetProps() != null)
                return;
            var model = new AppLocalProps { AuthToken = string.Empty };
            database.Insert(model);
        }

        public AppLocalProps GetProps()
        {
            return database.Table<AppLocalProps>().FirstOrDefault();
        }

        public void ApplySettings(AppLocalProps item)
        {
            database.Update(item);
        }
    }
}
