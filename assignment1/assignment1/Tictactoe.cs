using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    internal class Tictactoe
    {
        static char[,] gameBoard = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        static List<char> validCells = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public static void Play()
        {
            // Show playing rules at the start of the game.
            ShowGameRule();
            ShowBoard();
            int moveCount = 0;

            while (moveCount < 9)
            {
                // Prompt and wait for input from player    
                Console.WriteLine();
                PromptPlayer(moveCount);
                char playerInput = ReadPlayerMove();

                // Wait until valid player input
                while (!ValidatePlayerMove(playerInput))
                {
                    Console.WriteLine("Input is invalid, please enter again");
                    playerInput = ReadPlayerMove();
                }
                Wait(1);

                // Update the board
                int player = (moveCount % 2) + 1;
                UpdateBoard(playerInput, player);

                // Display board with new entry
                Console.Clear();
                ShowBoard();

                // Check if the move results in the game being won               
                bool gameWon = CheckWiningEntry(playerInput);

                if ((moveCount == 8) || gameWon)
                {
                    Console.WriteLine();
                    // Display winning message if a player won the game
                    if (gameWon)
                    {
                        Console.WriteLine("*******************************************");
                        Console.WriteLine("Congratulation player {0}. You won the game!", player);
                        Console.WriteLine("*******************************************");
                    }

                    else
                    {
                        Console.WriteLine("This game is a draw! ");
                    }

                    /*                
                    char playerAnswer = PromptNewGame();                         
                    if(playerAnswer == 'Y')
                    {   
                        Console.Clear();                 
                        moveCount = -1;               
                        RestartGame();
                        ShowGameRule();
                        ShowBoard();
                    }

                    else
                    {
                        break;
                    }  
                    */
                    break;
                }
                moveCount++;
            }
        }

        // Reset the board
        private static void ResetBoard()
        {
            gameBoard[0, 0] = '1';
            gameBoard[0, 1] = '2';
            gameBoard[0, 2] = '3';
            gameBoard[1, 0] = '4';
            gameBoard[1, 1] = '5';
            gameBoard[1, 2] = '6';
            gameBoard[2, 0] = '7';
            gameBoard[2, 1] = '8';
            gameBoard[2, 2] = '9';
        }

        // Reset list of user moves
        private static void ResetMoveList()
        {
            validCells.Clear();
            validCells.Add('1');
            validCells.Add('2');
            validCells.Add('3');
            validCells.Add('4');
            validCells.Add('5');
            validCells.Add('6');
            validCells.Add('7');
            validCells.Add('8');
            validCells.Add('9');
        }

        private static void RestartGame()
        {
            ResetBoard();
            ResetMoveList();
        }

        private static void ShowGameRule()
        {
            string rule1 = "1) Player #1 entry: O ,  Player #2 entry: X";
            string rule2 = "2) Entry can only be placed in numberred cell";
            string rule3 = "3) A player wins the game if his entries occurs in 3 consecutive cells, either horizontal or vertical or diagonal, the game is won.";
            Console.Clear();
            Wait(1);
            Console.WriteLine("====== TIC-TAC-TOE GAME RULES ======");
            Console.WriteLine(rule1);
            Console.WriteLine(rule2);
            Console.WriteLine(rule3);
            Console.WriteLine("====================================");
            Console.WriteLine();
        }

        // Inline delay in seconds
        private static void Wait(double x)
        {
            DateTime t = DateTime.Now;
            DateTime tf = DateTime.Now.AddSeconds(x);

            while (t < tf)
            {
                t = DateTime.Now;
            }
        }

        // Display the board with current status
        private static void ShowBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("===================");
                Console.WriteLine($"|  {gameBoard[i, 0]}  |  {gameBoard[i, 1]}  |  {gameBoard[i, 2]}  |");
            }
            Console.WriteLine("===================");
        }

        // Update board stats
        private static void UpdateBoard(char cellPosition, int player)
        {
            char defaultEntry = 'O';
            if (player == 2)
            {
                defaultEntry = 'X';
            };

            switch (cellPosition)
            {
                case '1':
                    {
                        gameBoard[0, 0] = defaultEntry;
                        break;
                    }

                case '2':
                    {
                        gameBoard[0, 1] = defaultEntry;
                        break;
                    }
                case '3':
                    {
                        gameBoard[0, 2] = defaultEntry;
                        break;
                    }
                case '4':
                    {
                        gameBoard[1, 0] = defaultEntry;
                        break;
                    }
                case '5':
                    {
                        gameBoard[1, 1] = defaultEntry;
                        break;
                    }
                case '6':
                    {
                        gameBoard[1, 2] = defaultEntry;
                        break;
                    }
                case '7':
                    {
                        gameBoard[2, 0] = defaultEntry;
                        break;
                    }
                case '8':
                    {
                        gameBoard[2, 1] = defaultEntry;
                        break;
                    }
                case '9':
                    {
                        gameBoard[2, 2] = defaultEntry;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        // Prompt player
        private static void PromptPlayer(int count)
        {
            int playerNum = (count % 2) + 1;
            Console.Write("Player #{0} turn - Please select a cell position. ", playerNum);
            Console.Write("Valid cells: ");
            for (int i = 0; i < validCells.Count - 1; i++)
            {
                Console.Write(validCells[i]);
                Console.Write(", ");
            }
            Console.WriteLine(validCells[validCells.Count - 1]);
        }

        // Check if a player select a valid cell
        private static bool ValidatePlayerMove(char cellNum)
        {
            bool valid = validCells.Contains(cellNum);
            if (valid)
            {
                validCells.Remove(cellNum);
            }
            return valid;
        }

        // Read player's move
        private static char ReadPlayerMove()
        {
            char input = 'A';
            string userInput = Console.ReadLine();

            if (userInput.Length == 1)
            {
                input = userInput[0];
            }
            return input;
        }

        // Ask if players want to play a new game
        private static char PromptNewGame()
        {
            Console.WriteLine("Do you want to start a new game? Y for yes, N for no.");
            string userInput = Console.ReadLine();
            char input = (userInput.ToUpper())[0];
            return input;
        }

        // Check if the specified row is the winning row
        private static bool CheckWiningRow(int row)
        {
            return (gameBoard[row, 0] == gameBoard[row, 1]) && (gameBoard[row, 0] == gameBoard[row, 2]);
        }

        // Check if the specified column is the winning column
        private static bool CheckWiningCol(int col)
        {
            return (gameBoard[0, col] == gameBoard[1, col]) && (gameBoard[0, col] == gameBoard[2, col]);
        }

        // Check diagonal for winning 
        private static bool CheckWiningDiagonal(int row, int col)
        {
            bool leftsideDiagonal = (gameBoard[0, 0] == gameBoard[1, 1]) && (gameBoard[0, 0] == gameBoard[2, 2]);
            bool rightsideDiagonal = (gameBoard[0, 2] == gameBoard[1, 1]) && (gameBoard[0, 2] == gameBoard[2, 0]);

            // Top-Left or Bottom-Right cell entry
            if ((row == 0 && col == 0) || (row == 2 && col == 2))
            {
                return leftsideDiagonal;
            }

            // Top-Right or Bottom-Left cell entry
            if ((row == 0 && col == 2) || (row == 2 && col == 0))
            {
                return rightsideDiagonal;
            }

            // Center cell entry
            if (row == 1 || col == 1)
            {
                return (leftsideDiagonal || rightsideDiagonal);
            }
            return false;
        }

        // This method checks if the move by a player resulted in winning the game
        private static bool CheckWiningEntry(char cellPosition)
        {
            int row = 0;
            int col = 0;

            switch (cellPosition)
            {
                case '1':
                    {
                        row = 0;
                        col = 0;
                        break;
                    }

                case '2':
                    {
                        row = 0;
                        col = 1;
                        break;
                    }
                case '3':
                    {
                        row = 0;
                        col = 2;
                        break;
                    }
                case '4':
                    {
                        row = 1;
                        col = 0;
                        break;
                    }
                case '5':
                    {
                        row = 1;
                        col = 1;
                        break;
                    }
                case '6':
                    {
                        row = 1;
                        col = 2;
                        break;
                    }
                case '7':
                    {
                        row = 2;
                        col = 0;
                        break;
                    }
                case '8':
                    {
                        row = 2;
                        col = 1;
                        break;
                    }
                case '9':
                    {
                        row = 2;
                        col = 2;
                        break;
                    }
            }
            // Check row for winning result
            if (CheckWiningRow(row)) { return true; }

            // Check column for winning result
            if (CheckWiningCol(col)) { return true; }

            // Check diagonal for winning result if needed
            if ((row == 0 && col == 0) || (row == 2 && col == 2) || (row == 0 && col == 2) || (row == 2 && col == 0) || (row == 1 && col == 1))
            {
                return CheckWiningDiagonal(row, col);
            }

            // Default is not a winning move
            return false;
        }
    }
}
