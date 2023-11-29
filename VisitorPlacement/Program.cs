using VisitorPlacementCore;

Event newEvent = new(50);
newEvent.AddStand(3, 10);
newEvent.AddStand(2, 10);
newEvent.AddStand(2, 8);
newEvent.PrintStands();

Console.WriteLine("Max visitors is: " + newEvent.MaxVisitors);

foreach(var visitor in newEvent.EventVisitors)
{
    Console.WriteLine($"{visitor.Id} {visitor.IsAdult}");
}