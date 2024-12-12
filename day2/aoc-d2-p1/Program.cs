using System.Text.RegularExpressions;

internal class Program
{
    public static readonly Regex Regex = new(@"^(\d+) (\d+) (\d+) (\d+) (\d+)$");

    private static void Main(string[] args)
    {
        var input = new StreamReader("..\\input.txt");
        var line = input.ReadLine();
        var reports = new List<Report>();
        while (line != null)
        {
            var report = new Report(line);
            reports.Add(report);
            line = input.ReadLine();
        }

        Console.WriteLine($"Safe Reports: {reports.Count(r => r.Safe)}");
    }
}

public enum SequenceType
{
    Ascending,
    Descending,
    Neither
}

public class Report
{
    public Report(string line)
    {
        var values = line.Split(' ');

        var result = AnalyzeArray(values.Select(v => int.Parse(v)).ToArray());
        MaxStep = result.largestStep;
        SequenceType = result.sequenceType;
        if (result.sequenceType != SequenceType.Neither && result.largestStep <= 3)
            Safe = true;
    }

    public bool Safe { get; }
    public object MaxStep { get; }
    public SequenceType SequenceType { get; }

    public static (SequenceType sequenceType, int largestStep) AnalyzeArray(int[] array)
    {
        if (array == null || array.Length < 2)
        {
            throw new ArgumentException("Array must contain at least two elements.");
        }

        bool isAscending = true;
        bool isDescending = true;
        int largestStep = 0;
        bool hasChange = false;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] != array[i - 1]) // Check for changes in value
            {
                hasChange = true;
                int step = Math.Abs(array[i] - array[i - 1]);
                largestStep = Math.Max(largestStep, step);

                if (array[i] > array[i - 1])
                {
                    isDescending = false;
                }
                else if (array[i] < array[i - 1])
                {
                    isAscending = false;
                }
            }
            else
            {
                isAscending = false;
                isDescending = false;
                break;
            }
        }

        SequenceType sequenceType;
        if (!hasChange || (!isAscending && !isDescending))
        {
            sequenceType = SequenceType.Neither;
        }
        else if (isAscending && !isDescending)
        {
            sequenceType = SequenceType.Ascending;
        }
        else if (!isAscending && isDescending)
        {
            sequenceType = SequenceType.Descending;
        }
        else
        {
            sequenceType = SequenceType.Neither;
        }

        return (sequenceType, largestStep);
    }
}
