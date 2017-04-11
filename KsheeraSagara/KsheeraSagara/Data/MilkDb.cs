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

        public void AddMember(Member member)
        {
            var memCon = _database.GetCollection<Member>("Members");
            if (memCon.Count() == 0)
                memCon.Insert(member);

            var res = memCon.Exists(x => x.AdharNo == member.AdharNo);
            if (res)
                throw new Exception("Member already exists");
            memCon.Insert(member);
        }

        public void UpdateMember(Member member)
        {
            var memCon = _database.GetCollection<Member>("Members");
            memCon.Update(member);
        }
    }
}
