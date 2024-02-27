using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            DisplayMenu();
            bool keepPlaying = true;
            while (keepPlaying)
            {
                Prompt();
                int input = ReadInput();
                bool invalidIput = (input < 1) || (input > 2);
                while (invalidIput)
                {
                    Console.WriteLine("Invalid selection. Please enter 1 for TICTACTOE, 2 for ROCK-PAPER-SCISSOR");
                    input = ReadInput();
                    invalidIput = (input < 1) || (input > 2);
                }

                if (input == 1)
                {
                    Tictactoe.Play();
                }
                else
                {
                    RockPaperScissor.Play();
                }

                // Game finished, ask user if they want to continue playing game
                Console.WriteLine("Do you like to continue playing? Y for yes, else to quit.");

                // Read user input
                char userReply = PromptToContinuePlaying();

                // If Y then display menu and retart from the beginning
                if (userReply == 'Y')
                {
                    Console.Clear();
                    DisplayMenu();
                    keepPlaying = true;
                }

                // If  else  the break out of the while loop
                else
                {
                    break;
                }
            }
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("** WELCOME TO MINH TRUONG'S GAMES **");
            Console.WriteLine("************************************");
            Console.WriteLine();
            Console.WriteLine("Press 1 for TICTACTOE game");
            Console.WriteLine("Press 2 for ROCK PAPER SCISSOR game");
            Console.WriteLine();
        }

        public static void Prompt()
        {
            Console.WriteLine("Please select a game to play.");
        }
        public static int ReadInput()
        {
            string stringInput = Console.ReadLine();
            char input = stringInput[0];
            return (input - '0');
        }

        public static char PromptToContinuePlaying()
        {
            string stringInput = Console.ReadLine().ToUpper();
            char input = stringInput[0];
            return (input);
        }
    }
}
