namespace aoc202302;

internal class Game
{
    private int _id;
    private List<(int, int, int)> _items = new List<(int, int, int)>();

    public int Id => _id;
    public int MaxRed => _items.Select(x => x.Item1).Max();
    public int MaxGreen => _items.Select(x => x.Item2).Max();
    public int MaxBlue => _items.Select(x => x.Item3).Max();

    public int MinimumPower => MaxRed * MaxGreen * MaxBlue;

    private Game(int id, List<(int, int, int)> items)
    {
        _id = id;
        _items = items;
    }

    public bool IsPossibleWithMax(int maxRed, int maxGreen, int maxBlue)
    {
        return MaxRed < maxRed && MaxGreen < maxGreen && MaxBlue < maxBlue;
    }

    public static Game FromLine(string line)
    {
        var gamePart = line.Split(':');
        var gameIdString = gamePart[0].Replace("Game ", "");
        int id = int.Parse(gameIdString);

        var roundsPart = gamePart[1];
        var rounds = roundsPart.Split(";");

        List<(int, int, int)> roundResults = new();
        foreach (var round in rounds)
        {
            int red = 0, green = 0, blue = 0;
            foreach (var item in round.Split(','))
            {
                var number = int.Parse(item.Trim().Split(" ")[0]);

                switch (item)
                {
                    case var x when item.EndsWith("blue"): blue = number; break;
                    case var x when item.EndsWith("red"): red = number; break;
                    case var x when item.EndsWith("green"): green = number; break;
                    default: throw new Exception("Unexpected input");
                }
            }

            roundResults.Add((red, green, blue));
        }

        return new Game(id, roundResults);
    }
}
