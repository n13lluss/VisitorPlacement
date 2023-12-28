using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementCore
{
    public class Stand
    {
        public string Stand_Letter { get; private set; }
        private List<Row> rows { get; } = new List<Row>();
        public ReadOnlyCollection<Row> Rows => rows.AsReadOnly();

        public Stand(string StandLetter)
        {
            Stand_Letter = StandLetter;
        }

        public void GenerateRows(int seatAmount)
        {
            int rowAmount = (int)Math.Ceiling((double)seatAmount / 10);

            for (int i = 0; i < rowAmount; i++)
            {
                Row row = new Row(rows.Count + 1);
                row.GenerateSeats((int)Math.Ceiling((double)seatAmount / rowAmount));
                rows.Add(row);
            }
        }

        private int GetRemainingSpace()
        {
            int remainingSpace = 0;

            foreach (Row row in rows)
            {
                remainingSpace += row.GetEmptySeatCount();
            }

            return remainingSpace;
        }

        private bool CheckIfFrontRowContainsAdult(Group group)
        {
            foreach (Seat seat in rows.First().Seats)
            {
                foreach (Visitor visitor in group.Visitors)
                {
                    if (seat.Visitor != null)
                    {
                        if (seat.Visitor.IsAdult && seat.Visitor == visitor)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool TryAddGroup(Group group)
        {
            if (group.Visitors.Count > GetRemainingSpace()) return false;

            if (group.CheckIfContainsChild())
            {
                foreach (Visitor visitor in group.Visitors.OrderBy(v => v.IsAdult))
                {
                    if (!visitor.IsAdult)
                    {
                        if (rows.First().TryAddVisitor(visitor))
                        {
                            visitor.IsSeated = true;
                            continue;
                        }

                        return false;
                    }

                    foreach (Row row in rows)
                    {
                        if (row.TryAddVisitor(visitor))
                        {
                            visitor.IsSeated = true;
                            break;
                        }
                    }

                    if (CheckIfFrontRowContainsAdult(group)) return false;
                }
            }

            foreach (Row row in rows)
            {
                if (row.TryAddGroup(group)) return true;
            }

            return false;
        }
    }
}
