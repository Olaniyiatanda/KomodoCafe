using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_InsuranceRepo
{
    public class BadgeProperties
    {
        public int BadgeId { get; set; }
        public List<string> DoorNames { get; set; } = new List<string>();    
        public string NameOfBadge { get; set; }

        public BadgeProperties() { }


        public BadgeProperties (int badgeId, List<string> doorNames, string nameOfBadge)
        {
            BadgeId = badgeId;
            DoorNames = doorNames;
            NameOfBadge = nameOfBadge;
        }

    }
}
