using System;

namespace GreenVsRed
{
    class Game
    {
        //Check if target is green.
        public bool IsGreen(Grid grid, Target target)
        {
            if (grid.Body[target.Row, target.Column] == "1")
                return true;
            else
                return false;

        }

        //Check for neighbours green count.
        public int GreenNeighbours(Grid grid, int row, int col)
        {
            int greenCount = 0;

            if (row - 1 >= 0 && col - 1 >= 0)
            {
                if (grid.Body[row - 1, col - 1] == "1")
                {
                    greenCount++;
                }
            }

            if (row - 1 >= 0 && col >= 0)
            {
                if (grid.Body[row - 1, col] == "1")
                {
                    greenCount++;
                }
            }

            if (row - 1 >= 0 && col + 1 < grid.getRow())
            {
                if (grid.Body[row - 1, col + 1] == "1")
                {
                    greenCount++;
                }
            }

            if (row < grid.getRow() && col + 1 < grid.getRow())
            {
                if (grid.Body[row, col + 1] == "1")
                {
                    greenCount++;
                }
            }

            if (row + 1 < grid.getRow() &&
                col + 1 < grid.getRow() &&
                row + 1 < grid.getColumn() &&
                col + 1 < grid.getColumn())
            {
                if (grid.Body[row + 1, col + 1] == "1")
                {
                    greenCount++;
                }
            }

            if (row + 1 < grid.getColumn() && col < grid.getColumn())
            {
                if (grid.Body[row + 1, col] == "1")
                {
                    greenCount++;
                }
            }

            if (row + 1 < grid.getColumn() && col - 1 >= 0)
            {
                if (grid.Body[row + 1, col - 1] == "1")
                {
                    greenCount++;
                }
            }

            if (row >= 0 && col - 1 >= 0)
            {
                if (grid.Body[row, col - 1] == "1")
                {
                    greenCount++;
                }
            }

            return greenCount;
        }

        //Displaying our score
        public void DisplayScore(int counter)
        {
            Console.WriteLine($"# expected result: {counter}");
        }

        //Green to Red | Red to Green Rule
        public int Play(Grid grid, int rounds, Target target, int counter)
        {
            for (int i = 0; i < rounds; i++)
            {
                string[,] nextGeneration = new string[grid.getRow(), grid.getColumn()];

                for (int row = 0; row < grid.getRow(); row++)
                {
                    for (int col = 0; col < grid.getColumn(); col++)
                    {
                        int countOfGreenCells = GreenNeighbours(grid, row, col);
                        if (grid.Body[row, col] == "0")
                        {
                            if (countOfGreenCells == 3 || countOfGreenCells == 6)
                            {
                                nextGeneration[row, col] = "1";
                            }
                            else
                            {
                                nextGeneration[row, col] = "0";
                            }
                        }
                        else if (grid.Body[row, col] == "1")
                        {
                            if (countOfGreenCells == 0 ||
                                countOfGreenCells == 1 ||
                                countOfGreenCells == 4 ||
                                countOfGreenCells == 5 ||
                                countOfGreenCells == 7 ||
                                countOfGreenCells == 8)
                            {
                                nextGeneration[row, col] = "0";
                            }
                            else
                            {
                                nextGeneration[row, col] = "1";
                            }
                        }
                    }
                }

                grid.Body = nextGeneration;

                if (IsGreen(grid, target))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
