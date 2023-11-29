using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementCore
{
    public class Visitor
    {
        public int Id { get; set; }
        public DateTime TicketBought { get; set; }
        public bool IsAdult { get; set; }

        public Visitor() { }

        public List<Visitor> CreateVisitors(int amount)
        {
            List<Visitor> Visitors = new List<Visitor>();

            for(int i = 0; i < amount; i++)
            {
                Visitor visitor = new()
                {
                    Id = i,
                };
            }

            return Visitors;
        }
    }
}
