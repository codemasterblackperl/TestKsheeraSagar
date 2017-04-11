using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using KsheeraSagara.Model;

namespace KsheeraSagara.Data
{
    public class MilkDb
    {
        readonly LiteDatabase _database;

        public MilkDb(string dbPath)
        {
            _database = new LiteDatabase(dbPath);
        }

        public List<Member> GetMembers()
        {
            var memCon = _database.GetCollection<Member>("Members");
            return memCon.FindAll().ToList();
        }
    }
}
