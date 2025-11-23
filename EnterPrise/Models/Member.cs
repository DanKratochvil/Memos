using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterPrise.Models
{
    public class Member
    {
        public string Name { get; set; } = string.Empty;
        public Member? Parent { get; set; }
        public List<Member> Children { get; set; } = new List<Member>();
        public bool IsInfected { get; set; } = false;
    }
}
