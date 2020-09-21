namespace GreenVsRed
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Input.ReadInputFromConsole();
            var grid = Input.FillTheGrid(dimensions);

            int rounds = 0;
            //Passing rounds by reference not by value.
            var target = Input.TargetAndGenerations(ref rounds);

            int counter = 0;

            Game game = new Game();

            //Checking if Generation Zero target is green.
            if (game.IsGreen(grid, target))
            {
                counter++;
            }

            counter = game.Play(grid, rounds, target, counter);

            game.DisplayScore(counter);
        }
    }
}
