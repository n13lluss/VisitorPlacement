using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementCore
{
    public class Event
    {
        public List<Stand>? Stands { get; set; } = [];
        public int MaxVisitors { get; set; }
        public List<Visitor> EventVisitors { get; set; } = [];

        public Event()
        {

        }
        public Event(int MaxVisitorAmount)
        {
            MaxVisitors = MaxVisitorAmount;
            AddRandomVisitors(15);
        }

        private static string IntToAlphabeticValue(int num)
        {
            if (num + 1 >= 1 && num <= 26 + 1)
            {
                // 'A' is represented by 65 in ASCII
                char alphabeticValue = (char)(num + 65);
                return alphabeticValue.ToString();
            }
            else
            {
                return "Number out of range (1-26)";
            }
        }

        public void PrintStands()
        {
            foreach (var stand in Stands)
            {
                var standCode = stand.Letter;
                foreach (var row in stand.Rows)
                {
                    var rowCode = row.Code;
                    foreach (var seat in row.Seats)
                    {
                        var seatCode = seat.Code;
                        Console.Write($"({standCode}{rowCode} - {seatCode})");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        public void AddStand(int rows, int seats)
        {
            Stand stand = new(rows, seats)
            {
                Letter = IntToAlphabeticValue(Stands.Count),
            };
            Stands.Add(stand);
        }

        public void AddRandomVisitors(int amount)
        {
            for (int i = 1; i <= amount; i++)
            {
                Visitor visitor = new()
                {
                    Id = i,
                    IsAdult = true;
                };
                EventVisitors.Add(visitor);
            }
        }
    }
}
