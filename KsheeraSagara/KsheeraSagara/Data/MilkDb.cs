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
            LoadSettings();
        }

        public void LoadSettings()
        {
            var setCon = _database.GetCollection<Settings>("MilkSettings");
            try
            {
                Shared.SharedValues._Settings = setCon.FindById(1);
            }
            catch
            {
                var settings = new Settings
                {
                    Id=1,
                    AppName = "Ksheera Sagara",
                    BuffaloMilkPrice=28,
                    CowMilkPrice=26,
                    LocalSalePrice=35
                };
                setCon.Insert(settings);
            }
        }

        public List<Member> GetMembers()
        {
            var memCon = _database.GetCollection<Member>("Members");
            if (memCon == null || memCon.Count() == 0)
                return new List<Member>();
            //var memlist = memCon.FindAll();
            //int count = memCon.Count();
            //var member = memlist.First();
            //var list = memlist.ToList();
            return new List<Member>();
        }

        public void AddMember(Member member)
        {
            var memCon = _database.GetCollection<Member>("Members");
            memCon.Insert(member);
        }

        public void UpdateMember(Member member)
        {
            var memCon = _database.GetCollection<Member>("Members");
            memCon.Update(member);
        }
    }
}
