using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    internal class RockPaperScissor
    {
        private static List<char> validEntry = new List<char> { 'R', 'P', 'S' };
        private static char pcInput = ' ';
        private static int playerScore = 0;
        private static int pcScore = 0;

        public static void Play()
        {
            ShowGameRule();

            for (int i = 0; i < 5; i++) // change 5 to whatever times you like
            {
                Prompt();
                char playerEntry = ReadPlayerInput();
                bool validEntry = ValidateInput(playerEntry);
                while (!validEntry)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input! Please enter R or P or S.");
                    Prompt();
                    playerEntry = ReadPlayerInput();
                    validEntry = ValidateInput(playerEntry);
                }
                pcInput = GeneratePcEntry();
                int result = CheckPlayerWin(playerEntry, pcInput);

                Console.WriteLine();
                Console.WriteLine("Your entry: {0}", playerEntry);
                Console.WriteLine("PC entry : {0}", pcInput);

                switch (result)
                {
                    case 0:
                        {
                            Console.WriteLine("It's a Tie!");
                            break;
                        }

                    case 1:
                        {
                            Console.WriteLine("You win!");
                            playerScore++;
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Computer win!");
                            pcScore++;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }

            // Display game score
            DisplayGameScores(playerScore, pcScore);
        }

        private static void ShowGameRule()
        {
            string rule1 = "1) You can only enter R (for Rock), P (for paper) and S (for scissor).";
            string rule2 = "2) The PC will generate a random value to play against your entry.";
            string rule3 = "3) A game will have 5 rounds.";
            Console.Clear();
            Console.WriteLine("====== ROCK PAPER SCISSOR GAME RULES ======");
            Console.WriteLine(rule1);
            Console.WriteLine(rule2);
            Console.WriteLine(rule3);
            Console.WriteLine("====================================");
            Console.WriteLine();
        }

        private static void Prompt()
        {
            Console.WriteLine("Please enter your entry. Valid values: R for rock, P for paper and S for scissor.");
        }
        // Read player's entry
        private static char ReadPlayerInput()
        {
            char input = 'A';
            string userInput = (Console.ReadLine()).ToUpper();

            if (userInput.Length == 1)
            {
                input = userInput[0];
            }
            return input;
        }

        // Check if a player select a valid cell
        private static bool ValidateInput(char input)
        {
            bool valid = validEntry.Contains(input);
            return valid;
        }

        // Generate a random input and returns as R or P or S
        private static char GeneratePcEntry()
        {
            Random rnd = new Random();
            int generatedValue = (rnd.Next(0, 30) % 3) + 1;
            char pcOutput = 'R';
            if (generatedValue == 1)
            {
                pcOutput = 'R';
            }

            if (generatedValue == 2)
            {
                pcOutput = 'P';
            }

            if (generatedValue == 3)
            {
                pcOutput = 'S';
            }
            return pcOutput;
        }

        // Check whether pc or player wins. Return values are 
        // 0 = tie, 1 = player wins, 2: pc wins
        private static int CheckPlayerWin(char playerInput, char pcInput)
        {
            int result;     // assuming player wins

            if (playerInput == pcInput)
            {
                result = 0;
            }

            else
            {
                // Assume player wins
                result = 1;
                switch (playerInput)
                {
                    case 'R':
                        {
                            if (pcInput == 'P')
                            {
                                result = 2;
                            }
                            break;
                        }
                    case 'P':
                        {
                            if (pcInput == 'S')
                            {
                                result = 2;
                            }
                            break;
                        }
                    case 'S':
                        {
                            if (pcInput == 'R')
                            {
                                result = 2;
                            }
                            break;
                        }
                }
            }

            return result;
        }

        // Display final game score
        private static void DisplayGameScores(int playerScore, int pcScore)
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("Your score: {0}", playerScore);
            Console.WriteLine("PC score: {0}", pcScore);

            string msg = "Congratulation! you won the game.";  // assume the player wins

            if (pcScore == playerScore)
            {
                msg = "Hm, you and the PC tied!";
            }

            if (pcScore > playerScore)
            {
                msg = "Sorry, the PC has outplayed you!";
            }

            Console.WriteLine(msg);
        }

    }
}
