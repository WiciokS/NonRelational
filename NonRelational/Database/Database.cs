using LiteDB;

namespace NonRelational.Database
{
    public class Database
    {
        public LiteDatabase LiteDatabase { get; private set; } = null;

        public Database(string connectionString)
        {
            if (LiteDatabase == null)
            {
                LiteDatabase = new LiteDatabase(connectionString);
                LiteDatabase.GetCollection<ThemeObject>("themes").EnsureIndex(x => x.Theme);
            }
        }

        public List<ThemeObject> GetThemes()
        {
            var collection = LiteDatabase.GetCollection<ThemeObject>("themes");
            return collection.FindAll().ToList();
        }

        public ThemeObject GetTheme(string theme)
        {
            var collection = LiteDatabase.GetCollection<ThemeObject>("themes");
            return collection.FindOne(x => x.Theme == theme);
        }

        public void InsertTheme(ThemeObject theme)
        {
            var collection = LiteDatabase.GetCollection<ThemeObject>("themes");
            collection.Insert(theme);
        }

        public void UpdateTheme(ThemeObject theme)
        {
            var collection = LiteDatabase.GetCollection<ThemeObject>("themes");
            collection.Update(theme);
        }
    }
}