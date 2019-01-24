using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_App.Models
{
    public abstract class ModelBase<T>
    {
        public int Id { get; set; }

        private static LiteDatabase __db;
        /// <summary>
        /// Returns a database object
        /// </summary>
        /// <returns></returns>
        public static LiteDatabase GetDatabase()
        {
            if (__db == null)
                __db = new LiteDatabase(Environment.CurrentDirectory + "\\Budget.db");
            return __db;
        }

        public static LiteCollection<T> GetCollection()
        {
            return GetDatabase().GetCollection<T>();
        }

        public static void CloseDatabase()
        {
            if(__db != null)
            {
                __db.Dispose();
                __db = null;
            }
        }
    }
}
