using System;
using System.Linq;


namespace GreenVsRed
{
    class Input
    {
        public static int[] ReadInputFromConsole()
        {

            return Console.ReadLine()
                            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
        }

        public static Target TargetAndGenerations(ref int rolls)
        {
            var input = ReadInputFromConsole();
            int rowCoordinate = input[1];
            int colCoordinate = input[0];

            var target = new Target(rowCoordinate, colCoordinate);
            rolls = input[2];

            return target;
        }

        public static Grid FillTheGrid(int[] dimentions)
        {
            var grid = new Grid(dimentions[1], dimentions[0]);

            for (int i = 0; i < grid.getRow(); i++)
            {
                char[] inputRow = Console.ReadLine().ToCharArray();

                for (int j = 0; j < grid.getColumn(); j++)
                {
                    grid.Body[i, j] = inputRow[j].ToString();
                }
            }

            return grid;
        }
    }
}
