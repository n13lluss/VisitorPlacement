using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementCore
{
    public class Group
    {
        public int Group_Id { get; private set; }
        public DateTime RegistrationDate { get; set; }
        private List<Visitor> visitors { get; set; } = new List<Visitor>();
        public ReadOnlyCollection<Visitor> Visitors => visitors.AsReadOnly();

        public Group(int group_Id)
        {
            Group_Id = group_Id;
        }

        public void AddVisitor(Visitor visitor)
        {
            visitors.Add(visitor);
            RegistrationDate = visitor.RegistrationDate;
        }

        public bool CheckIfContainsChild()
        {
            foreach (Visitor visitor in visitors)
            {
                if (!visitor.IsAdult)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckIfContainsAdult()
        {
            foreach (Visitor visitor in visitors)
            {
                if (visitor.IsAdult)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckIfIsSeated()
        {
            foreach (Visitor visitor in visitors)
            {
                if (!visitor.IsSeated)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
