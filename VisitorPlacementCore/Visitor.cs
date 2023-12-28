using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementCore
{
    public class Visitor
    {
        public int VisitorId { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsSeated { get; set; } = false;
        public bool IsAdult { get; set; } = true;

        public Visitor(string name, int groupid, DateOnly birthdate)
        {
            Name = name;
            GroupId = groupid;

            if (DateTime.Now.Year - birthdate.Year <= 12)
            {
                IsAdult = false;
            }
        }

        // Checks if the registration date has passed
        public bool CheckIfVisitorOnTime(DateTime eventStartDateTime)
        {
            if (eventStartDateTime.Ticks - DateTime.Now.Ticks < 0)
            {
                return false;
            }

            return true;
        }
    }
}
