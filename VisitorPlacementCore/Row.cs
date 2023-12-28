using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementCore
{
    public class Row
    {
        public int RowNumber { get; private set; }
        private List<Seat> seats = new List<Seat>();
        public ReadOnlyCollection<Seat> Seats => seats.AsReadOnly();

        public Row(int rowNumber)
        {
            RowNumber = rowNumber;
        }

        public int GetEmptySeatCount()
        {
            int emptySeatCount = 0;

            foreach (Seat seat in seats)
            {
                if (seat.Visitor != null) continue;

                emptySeatCount++;
            }

            return emptySeatCount;
        }

        public bool TryAddGroup(Group group)
        {
            foreach (Visitor visitor in group.Visitors)
            {
                if (RowNumber == 1)
                {
                    foreach (Seat seat in Seats)
                    {
                        if (!seat.TryAddGroup(group)) return false;
                    }
                }

                if (TryAddVisitor(visitor))
                {
                    visitor.IsSeated = true;
                }
            }

            if (group.CheckIfIsSeated()) return true;

            return false;
        }

        public bool TryAddVisitor(Visitor visitor)
        {
            if (!visitor.IsAdult && RowNumber != 1) return false;

            if (!visitor.IsSeated)
            {
                foreach (Seat seat in seats)
                {
                    if (seat.TryAddVisitor(visitor))
                    {
                        visitor.IsSeated = true;
                        return true;
                    }
                }
            }

            return false;
        }

        public void GenerateSeats(int SeatAmount)
        {
            for (int i = 0; i < SeatAmount; i++)
            {
                seats.Add(new Seat(seats.Count + 1));
            }
        }
    }
}
