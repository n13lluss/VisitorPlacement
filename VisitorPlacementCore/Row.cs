using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementCore
{
    public class Row
    {
        public string Code {  get; set; }
        public List<Seat> Seats { get; set; } = [];

        public Row(int amount)
        {
            for(int i = 1; i <= amount; i++)
            {
                Seat seat = new()
                {
                    Code = i.ToString(),
                };
                Seats.Add(seat);
            }
        }
    }
}
