namespace aoc202302;

internal class Program
{
    private const int MaxRed = 12;
    private const int MaxGreen = 13;
    private const int MaxBlue = 14;

    static void Main(string[] args)
    {
        int sum = 0;
        string? line;
        while ((line = Console.ReadLine()) != null)
        {
            Game game = Game.FromLine(line);

            /*
            if (game.IsPossibleWithMax(MaxRed, MaxGreen, MaxBlue))
            {
                sum += game.Id;
            }
            */

            sum += game.MinimumPower;
        }

        Console.WriteLine(sum);
    }
}