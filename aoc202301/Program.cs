namespace aoc202301;

internal class Program
{
    private static readonly Dictionary<string, string> Numbers = new Dictionary<string, string>()
    {
        {"zero", "0" },
        {"one", "1" },
        {"two", "2" },
        {"three", "3"},
        {"four", "4"},
        {"five", "5" },
        {"six", "6" },
        {"seven", "7" },
        {"eight", "8" },
        {"nine", "9" }
    };

    static void Main(string[] args)
    {
        int sum = 0;

        string? line;
        while ((line  = Console.ReadLine()) != null)
        {
            int calibrationValue = GetCalibrationValueFromLine(line);
            Console.WriteLine($"Found calibration value {calibrationValue}");
            sum += calibrationValue;
        }

        Console.WriteLine(sum);
    }

    private static int GetCalibrationValueFromLine(string line)
    {
        var forwardLine = ReplaceFirstNumber(line);
        var backwardLine = ReplaceLastNumber(line);

        return GetFirstNumber(forwardLine) * 10 + GetLastNumber(backwardLine);
    }

    private static string ReplaceFirstNumber(string line)
    {
        var result = "";

        for (int i = 0; i < line.Length; i++)
        {
            var subline = line.Substring(i);

            if (Numbers.Keys.Any(x => subline.StartsWith(x)))
            {
                var number = Numbers.Keys.Single(x => subline.StartsWith(x));
                result += Numbers[number];
                i += number.Length - 1;
            }
            else
            {
                result += line[i];
            }
        }

        return result;
    }

    private static string ReplaceLastNumber(string line)
    {
        var result = "";

        for (int i = line.Length; i > 0; i--)
        {
            var subline = line.Substring(0, i);

            if (Numbers.Keys.Any(x => subline.EndsWith(x)))
            {
                var number = Numbers.Keys.Single(x => subline.EndsWith(x));
                result = Numbers[number] + result;
                i -= number.Length + 1;
            }
            else
            {
                result = line[i -  1] + result;
            }
        }

        return result;
    }

    private static int GetLastNumber(string line)
    {
        return GetFirstNumber(line.ReverseString());
    }

    private static int GetFirstNumber(string line)
    {
        foreach (char c in line)
        {
            if (char.IsDigit(c))
            {
                return int.Parse($"{c}");
            }
        }

        throw new Exception("No number in the string");
    }
}

internal static class Extensions
{ 
    public static string ReverseString(this string s)
    {
        return s.Reverse().Aggregate("", (a, b) => $"{a}{b}");
    }
}
