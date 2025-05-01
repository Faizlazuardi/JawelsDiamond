using JawelsDiamond.Models;

namespace JawelsDiamond.Repository
{
    public class DatabaseSingleton
    {
        private static DbEntities db = null;

        private DatabaseSingleton()
        {

        }

        public static DbEntities GetInstance()
        {
            if (db == null)
            {
                db = new DbEntities();
            }
            return db;
        }
    }
}