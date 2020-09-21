using System;

namespace TicTacToe
{
    class Program
    {
        static string[] board = { " ", " ", " ", " ", " ", " ", " ", " ", " " };

        static void DrawBoard()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("| {0} | {1} | {2} |", board[0],board[1],board[2]);
            Console.WriteLine("| {0} | {1} | {2} |", board[3], board[4], board[5]);
            Console.WriteLine("| {0} | {1} | {2} |", board[6], board[7], board[8]);
            Console.WriteLine("-------------------");
        }

        static void ResetBoard()
        {
            Console.WriteLine("Would you like to play again y/n");
            char answer = char.Parse(Console.ReadLine());

            if (answer == 'y')
            {
                board[0] = " ";
                board[1] = " ";
                board[2] = " ";
                board[3] = " ";
                board[4] = " ";
                board[5] = " ";
                board[6] = " ";
                board[7] = " ";
                board[8] = " ";
                DrawBoard();
                Play();
            }
            else
                System.Environment.Exit(0);
        }
        static void Play()
        {
            Console.WriteLine("Enter the spot!");
            int spot = int.Parse(Console.ReadLine());
            int index = spot - 1;

            if (isSpotOpen(index))
            {
                board[index] = "X";
            }
            else
            {
                Play();
            }
            if (CheckForWinner())
            {
                DrawBoard();
                Console.WriteLine("Congratulations!You won!!");
                ResetBoard();
            }
            else
            {
                CheckDraw();
            }
            OpponentMove();
            DrawBoard();
            Play();

        }

        static void OpponentMove()
        {
            int[] openSpots = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            int count = 0;
            int winningPosition = 0;
            for (int i = 0; i <= 8; i++)
            {
                if (board[i] == " ")
                {
                    openSpots[count] = i;
                    count = count + 1;
                }
            }
            //check for winning move for computer
            winningPosition = checkWinningMove("O", openSpots);
            if (winningPosition != -1)
            {
                board[winningPosition] = "O";
            }
            else
            {
                //Check for winning position for player
                winningPosition = checkWinningMove("X", openSpots);
                if (winningPosition != -1)
                {
                    board[winningPosition] = "O";
                }
                else
                {
                    // No winning position found; choose a random spot
                    Random rnd = new Random();
                    int randomInteger = rnd.Next(0, count);
                    board[openSpots[randomInteger]] = "O";
                }
            }
            if (CheckForWinner() == true)
            {
                DrawBoard();
                Console.WriteLine("You lose!");
                ResetBoard();
                Play();
            }
        }

        static int checkWinningMove(string player, int[] openSpots)
        {
            int maxAvailable = 0;
            for (int i = 0; i <= openSpots.Length - 1; i++)
            {
                if (openSpots[i] != -1) { maxAvailable = i; };
            }

            for (int i = 0; i <= maxAvailable; i++)
            {
                if (board[openSpots[i]] == " ")
                {
                    board[openSpots[i]] = player;
                    if (CheckForWinner() == true)
                    {
                        return (openSpots[i]);
                    }
                }
                board[openSpots[i]] = " ";
            }
            return -1;
        }

        static bool CheckDraw()
        {
            if ((board[0] != " " && CheckForWinner() == false) &&
                (board[1] != " " && CheckForWinner() == false) &&
                (board[2] != " " && CheckForWinner() == false) &&
                (board[3] != " " && CheckForWinner() == false) &&
                (board[4] != " " && CheckForWinner() == false) &&
                (board[5] != " " && CheckForWinner() == false) &&
                (board[6] != " " && CheckForWinner() == false) &&
                (board[7] != " " && CheckForWinner() == false) &&
                (board[8] != " " && CheckForWinner() == false))
            {
                Console.WriteLine("Draw.");
                ResetBoard();
                return true;
            }
            else
            {
                return false;
            }
        }

     
        static bool CheckForWinner()
        {
            if (
                 (board[0] == board[1] && board[1] == board[2] && board[2] != " ") ||
                 (board[3] == board[4] && board[4] == board[5] && board[5] != " ") ||
                 (board[6] == board[7] && board[7] == board[8] && board[8] != " ") ||
                 (board[0] == board[4] && board[4] == board[8] && board[8] != " ") ||
                 (board[2] == board[4] && board[4] == board[6] && board[6] != " ") ||
                 (board[0] == board[3] && board[3] == board[6] && board[6] != " ") ||
                 (board[1] == board[4] && board[4] == board[7] && board[7] != " ") ||
                 (board[2] == board[5] && board[5] == board[8] && board[8] != " ")
                 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool isSpotOpen(int spot)
        {
            if (board[spot] == "X" || board[spot] == "O")
            {
                Console.WriteLine("Oops that spot is taken. Try again");
                return false;
            }
            else
            {
                return true;
            }

        }
        static void Main(string[] args)
        {
            DrawBoard();
            Play();
        }
    }
}
