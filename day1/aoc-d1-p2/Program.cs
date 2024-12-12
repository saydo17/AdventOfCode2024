using System.Text.RegularExpressions;
using System.Linq;

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

    var sum = 0;
    foreach (var number in leftNumbers)
    {
        var similarity = number * rightNumbers.Where(n => n == number).Count();
        sum += similarity;
    }

    Console.WriteLine(sum);
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
