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

        public List<ScoreBoardEntryObject> GetScoreBoardList()
        {
            var collection = LiteDatabase.GetCollection<ScoreBoardEntryObject>("scoreboard");
            return collection.FindAll().ToList();
        }

        public void InsertScoreBoardEntry(ScoreBoardEntryObject entry)
        {
            var collection = LiteDatabase.GetCollection<ScoreBoardEntryObject>("scoreboard");
            collection.Insert(entry);
        }

        public void UpdateScoreBoardEntry(ScoreBoardEntryObject entry)
        {
            var collection = LiteDatabase.GetCollection<ScoreBoardEntryObject>("scoreboard");
            collection.Update(entry);
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