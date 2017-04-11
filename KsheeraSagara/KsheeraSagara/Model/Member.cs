using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsheeraSagara.Model
{
    public class Member
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public string MemberType { get; set; }
        public string Name { get; set; }
        public string KMFUid { get; set; }
        public long AdharNo { get; set; }
        public string PhoneNumber { get; set; }
        public string Caste { get; set; }
        public string Occupation { get; set; }
        public string BankName { get; set; }
        public string BankBranchName { get; set; }
        public string IFSC { get; set; }
        public string AccountNumber { get; set; }
    }
}
