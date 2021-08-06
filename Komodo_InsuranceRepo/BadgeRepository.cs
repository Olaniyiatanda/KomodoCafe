using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_InsuranceRepo
{
    public class BadgeRepository

    {
        Dictionary<int, List<string>> badges = new Dictionary<int, List<string>>();

        public Dictionary<int, List<string>> GetDictionary()
        {
            return badges;

        }

        //Create 
        public void Addbadge(BadgeProperties badge)
        {
            badges.Add(badge.BadgeId, badge.DoorNames);
        }

        //Open Doors
        // look at the key value pair as  your badge, the badge id is the key and the list of doors is the value
        public void AddDoorsToBadge(int badgeId, string doorName)  
        {
            //BadgeProperties Badge = new BadgeProperties();
            KeyValuePair<int, List<string>> kvp = GetBadgeByBadgeId(badgeId);
            kvp.Value.Add(doorName);
            
        }

        // Badge No1 => A1.A2.A3.A4.A5-(A2)+A6

        public void RemoveDoorsFromBadge(int badgeId, string doorname)
        {
            //BadgeProperties Badge = new BadgeProperties();
            KeyValuePair<int, List<string>> kvp = GetBadgeByBadgeId(badgeId);
            List<string> DoorList = kvp.Value;
            foreach (var door in DoorList)
            {
                if (door == doorname)
                {
                    DoorList.Remove(door);
                    
                }
               
            }


        }

        public void ReplaceDoor(int badgeId,string OldDoor, string newDoor)
        {
            RemoveDoorsFromBadge(badgeId, OldDoor);
            AddDoorsToBadge(badgeId, newDoor);
        }


        //Helper Method 
       public KeyValuePair<int,List<string>>GetBadgeByBadgeId(int badgeId)
        {

            KeyValuePair<int, List<string>> kvp = new KeyValuePair<int, List<string>>();
            foreach (KeyValuePair<int, List<string>> item in badges )
            {
                if (item.Key == badgeId)
                {
                    return item;
                }
               
            }
            return kvp;
            

        }

        public bool DeleteBadge(int Badgeid)
        {
             var kvp = GetBadgeByBadgeId(Badgeid);
           // badges.Remove(Badgeid);
            if (badges.Remove(kvp.Key))
            {
                return true;
            }
            return false;

        }







    }













    
}
