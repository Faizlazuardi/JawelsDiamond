using System.Data.Entity.Infrastructure;

namespace JawelsDiamond.Repositories
{
    public class DatabaseSingleton
    {
        private static DbModel db = null;

        private DatabaseSingleton()
        {

        }

        public static DbModel GetInstance()
        {
            if (db == null)
            {
                db = new DbModel();
            }
            return db;
        }
    }
}