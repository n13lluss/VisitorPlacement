using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace VisitorPlacementCore
{
    public class Event
    {
        public int MaxVisitors { get; private set; }
        public int VisitorsCount { get; private set; }
        public List<Stand> GrandStand { get; private set; } = new List<Stand>();
        public List<Visitor> Rejected_Visitors { get; private set; } = new List<Visitor>();
        public List<Group> Groups { get; private set; } = new List<Group>();
        public DateTime EventStartingDate { get; private set; }

        private readonly string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Event(int maxvisitors, DateTime eventstart)
        {
            MaxVisitors = maxvisitors;
            EventStartingDate = eventstart;
        }

        public void RegisterVisitor(Visitor visitor)
        {
            // Check if the visitor is already registered.
            if (visitor.VisitorId != 0) return;

            // Check if they're on time and if they fit.
            if (!visitor.CheckIfVisitorOnTime(EventStartingDate) || VisitorsCount + 1 > MaxVisitors)
            {
                Rejected_Visitors.Add(visitor);
                return;
            }

            // Try add visitor to existing group, create a new group if not.
            if (!TryAddVisitorToExistingGroups(visitor, visitor.GroupId) || visitor.GroupId < 1)
            {
                AddVisitorToNewGroup(visitor, visitor.GroupId);
            }

            VisitorsCount++;
            visitor.VisitorId = VisitorsCount;
        }

        // Tries to add a visitor to an already existing group
        private bool TryAddVisitorToExistingGroups(Visitor visitor, int groupid)
        {
            foreach (Group group in Groups)
            {
                if (group.Group_Id == groupid)
                {
                    group.AddVisitor(visitor);
                    VisitorsCount++;
                    visitor.VisitorId = VisitorsCount;

                    return true;
                }
            }

            return false;
        }

        // Creates a new group to add a visitor to.
        private void AddVisitorToNewGroup(Visitor visitor, int groupid)
        {
            Group newgroup = new Group(groupid);
            newgroup.AddVisitor(visitor);
            Groups.Add(newgroup);
        }

        // Generate GrandStand, Rows and Seats
        public bool GenerateSeating()
        {
            for (int i = 0; i < MaxVisitors / 30; i++)
            {
                Stand Stand = new Stand(Alphabet.Substring(GrandStand.Count, 1));
                Stand.GenerateRows(30);
                GrandStand.Add(Stand);
            }

            if (MaxVisitors % 30 > 0)
            {
                Stand Stand = new Stand(Alphabet.Substring(GrandStand.Count, 1));
                Stand.GenerateRows(MaxVisitors % 30);
                GrandStand.Add(Stand);
            }

            return true;
        }

        // Assign seats to Visitors (or Visitors to seats?)
        public List<Stand> AssignSeats()
        {
            Groups = RemoveChildOnlyGroups(Groups);

            Groups = Groups.OrderByDescending(g => g.CheckIfContainsChild()).ThenBy(g => g.RegistrationDate).ToList();

            foreach (Group group in Groups)
            {
                foreach (Stand Stand in GrandStand)
                {
                    if (Stand.TryAddGroup(group)) break;
                }
            }

            return GrandStand;
        }

        // Removes all the groups that don't have adults in them.
        private List<Group> RemoveChildOnlyGroups(List<Group> groups)
        {
            for (int i = groups.Count; i > 0; i--)
            {
                if (!groups[i - 1].CheckIfContainsAdult())
                {
                    foreach (Visitor visitor in groups[i - 1].Visitors)
                    {
                        Rejected_Visitors.Add(visitor);
                    }

                    groups.RemoveAt(i - 1);
                }
            }

            return groups;
        }
    }
}
