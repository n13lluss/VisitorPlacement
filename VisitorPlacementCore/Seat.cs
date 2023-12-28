using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementCore
{
    public class Seat
    {
        public int SeatNumber { get; private set; }
        public Visitor? Visitor { get; set; }

        public Seat(int seatNumber)
        {
            SeatNumber = seatNumber;
        }

        public bool TryAddVisitor(Visitor visitor)
        {
            if (Visitor == null)
            {
                Visitor = visitor;
                return true;
            }

            return false;
        }

        public bool TryAddGroup(Group group)
        {
            foreach (Visitor visitor in group.Visitors)
            {
                if (Visitor == visitor && visitor.IsAdult) return false;
            }

            return true;
        }
    }
}
