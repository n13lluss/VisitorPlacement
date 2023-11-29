using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementCore
{
    public class Group
    {
        public int Id { get; set; }
        public List<Visitor> Visitors { get; set; }
        public DateTime TicketBought { get; set; }
    }
}
