using VisitorPlacementCore;

// Create Event instance.
Event Event = new Event(100, new DateTime(2024, 6, 20, 20, 0, 0));

// Create Visitors.
Event.RegisterVisitor(new Visitor("Alice", 1, new DateOnly(2001, 6, 20)));
Event.RegisterVisitor(new Visitor("Erik", 1, new DateOnly(1997, 2, 17)));
Event.RegisterVisitor(new Visitor("Sophie", 1, new DateOnly(1987, 11, 24)));
Event.RegisterVisitor(new Visitor("Charlie", 2, new DateOnly(2001, 6, 20)));
Event.RegisterVisitor(new Visitor("Olivia", 2, new DateOnly(1997, 2, 17)));
Event.RegisterVisitor(new Visitor("Maxwell", 3, new DateOnly(1987, 11, 24)));
Event.RegisterVisitor(new Visitor("Luna", 4, new DateOnly(2001, 6, 20)));
Event.RegisterVisitor(new Visitor("Finn", 5, new DateOnly(1997, 2, 17)));
Event.RegisterVisitor(new Visitor("Isabella", 5, new DateOnly(1987, 11, 24)));
Event.RegisterVisitor(new Visitor("William", 6, new DateOnly(1997, 2, 17)));
Event.RegisterVisitor(new Visitor("Mia", 6, new DateOnly(1997, 2, 17)));
Event.RegisterVisitor(new Visitor("Oscar", 6, new DateOnly(1987, 11, 24)));
Event.RegisterVisitor(new Visitor("ChildKarel", 6, new DateOnly(2013, 11, 24)));

//Event.RegisterVisitor(new Visitor("Emma", 7, new DateOnly(1987, 4, 15)));
//Event.RegisterVisitor(new Visitor("ChildNoah", 7, new DateOnly(2013, 9, 3)));
//Event.RegisterVisitor(new Visitor("ChildAva", 7, new DateOnly(2012, 12, 8)));
//Event.RegisterVisitor(new Visitor("Liam", 8, new DateOnly(1987, 7, 19)));
//Event.RegisterVisitor(new Visitor("ChildCharlotte", 8, new DateOnly(2012, 2, 28)));
//Event.RegisterVisitor(new Visitor("ChildHenry", 8, new DateOnly(2012, 10, 5)));
//Event.RegisterVisitor(new Visitor("Grace", 9, new DateOnly(1987, 11, 11)));
//Event.RegisterVisitor(new Visitor("ChildEthan", 9, new DateOnly(2015, 6, 7)));
//Event.RegisterVisitor(new Visitor("Zoe", 10, new DateOnly(1987, 3, 22)));
//Event.RegisterVisitor(new Visitor("ChildJackson", 10, new DateOnly(2017, 8, 14)));

//Event.RegisterVisitor(new Visitor("Sophia", 11, new DateOnly(2005, 5, 10)));
//Event.RegisterVisitor(new Visitor("ChildElijah", 12, new DateOnly(2017, 1, 25)));
//Event.RegisterVisitor(new Visitor("ChildAvery", 12, new DateOnly(2017, 7, 3)));
//Event.RegisterVisitor(new Visitor("ChildCaleb", 12, new DateOnly(2017, 9, 18)));
//Event.RegisterVisitor(new Visitor("ChildAria", 12, new DateOnly(2017, 12, 4)));


// Generate Stands
Event.GenerateSeating();

// Assign Seats
Event.AssignSeats();

// Print Results in Console
foreach (Stand Stand in Event.GrandStand)
{
    Console.WriteLine(Stand.Stand_Letter);
    foreach (Row row in Stand.Rows)
    {
        foreach (Seat seat in row.Seats)
        {
            if (seat.Visitor != null)
            {
                Console.Write(seat.Visitor.Name + " ");
                continue;
            }
            Console.Write(Stand.Stand_Letter + row.RowNumber + "-" + seat.SeatNumber + " ");
        }
        Console.WriteLine(" ");
    }
    Console.WriteLine(" ");
}

Console.WriteLine("Rejected Visitors:");

if (Event.Rejected_Visitors.Count <= 0)
{
    Console.WriteLine("None!");
    return;
}

foreach (Visitor visitor in Event.Rejected_Visitors)
{
    Console.WriteLine(visitor.Name);
}
