using System.Text.RegularExpressions;

string? line;

try
{
    var input = new StreamReader("..\\input.txt");
    line = input.ReadLine();
    var regex = new Regex(@"^(\d+)   (\d+)$");

    var leftNumbers = new List<int>();
    var rightNumbers = new List<int>();
    while (line != null)
    {
        var match = regex.Match(line);
        // Console.WriteLine(line);
        var result = int.TryParse(match.Groups[1].Value, out var left);
        if (!result)
            throw new Exception("Failed to parse left value");
        result = int.TryParse(match.Groups[2].Value, out var right);
        if (!result)
            throw new Exception("Failed to parse right value");
        leftNumbers.Add(left);
        rightNumbers.Add(right);

        line = input.ReadLine();
    }

    leftNumbers.Sort();
    rightNumbers.Sort();
    var difference = 0;
    for (var i = 0; i < leftNumbers.Count; i++)
    {
        var left = leftNumbers[i];
        var right = rightNumbers[i];
        var diff = Math.Abs(left - right);
        Console.WriteLine($"left: {left} right: {right} diff: {diff}");
        difference += diff;
    }

    Console.WriteLine($"Difference: {difference}");
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
    Console.WriteLine(e.StackTrace);
}
finally
{
    Console.WriteLine("Executing finally block.");
}
