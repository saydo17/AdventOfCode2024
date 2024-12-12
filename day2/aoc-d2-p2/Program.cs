var input = new StreamReader("..\\testInput.txt");
var line = input.ReadLine();
var reports = new List<Report>();
while (line != null)
{
    var report = new Report(line);
    reports.Add(report);
    line = input.ReadLine();
}

public class Report
{
    public Report(string input)
    {
        var values = input.Split(' ').Select(v => int.Parse(v)).ToArray();
    }
}

public enum Direction
{
    Start,
    Increasing,
    None,
    Decreasing,
}

public class Transition
{
    public Transition(int first, int second, Direction previousDirection)
    {
        var diff = first - second;
        if(diff == 0) Direction = Direction.None
        if(diff < 0) Direction = Direction.Decreasing
        if(diff > 0) Direction = Direction.Increasing;

        if (previousDirection != Direction.Start || Direction != previousDirection)
            Problem = true;
        

        if(diff > 3)
            Problem = true;
    }

    public bool Problem {get;}

    public Direction Direction {get;}
}
