using System;
using System.Linq;

namespace RockPaperScissors
{
    class Validation
    {
        public static Roshambo RPSInput(string userInput)   //Check for valid user input
        {
            Roshambo result = 0;
            string[] acceptedInput = { "r", "p", "s", "rock", "paper", "scissors", "1", "2", "3" };
            while (!acceptedInput.Contains(userInput))
            {
                Console.Write("Please enter valid input. (1)rock, (2)paper, (3) scissors: ");
                userInput = Console.ReadLine().ToLower();
            }
            if (userInput == "r" || userInput == "rock" || userInput == "1")
            {
                result = Roshambo.rock;
            }
            else if (userInput == "p" || userInput == "paper" || userInput == "2")
            {
                result = Roshambo.paper;
            }
            else if (userInput == "s" || userInput == "scissors" || userInput == "3")
            {
                result = Roshambo.scissors;
            }
            return result;
        }

        public static bool YesOrNo(string userInput, ref bool continueFlag) //Checks to continue or not and returns bool
        {
            while (userInput.ToLower() != "y" && userInput.ToLower() != "n")
            {
                Console.WriteLine("Please enter valid input (y/n): ");
                userInput = Console.ReadLine();
            }
            if (userInput == "n")
            {
                continueFlag = false;
            }
            Console.WriteLine();
            return continueFlag;
        }

        public static string GetName()  //Gets user name
        {
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();
            return userName;
        }

        public static Player GetOpponent()  //Gets opponent and creates the object based off of name chosen
        {
            Console.Write("Who would you like to play against? (Phil or Adom): ");
            string userChoice = Console.ReadLine().ToLower();
            while (userChoice != "phil" && userChoice != "adom")    //Makes sure input is valid
            {
                Console.Write("Please enter a valid opponent (Phil or Adom): ");
                userChoice = Console.ReadLine().ToLower();
            }
            if (userChoice == "phil") 
            {
                Player Phil = new RockMan();    ////Make a Phil!
                Phil.Name = "Phil";
                Console.WriteLine();
                return Phil;
            }
            else
            {
                Player Adom = new RandomMan();   //Make an Adom!
                Adom.Name = "Adom";
                Console.WriteLine();
                return Adom;
            }
        }
        public static void RPSOutcome(Player user, Player opponent, string userName, string opponentName)
        {
            Console.WriteLine($"\n{userName}: {user.RPS}"); //Show results of user choice
            Console.WriteLine($"{opponentName}: {opponent.RPS}");   //Shows opponent result
            if (user.RPS == opponent.RPS)   //Draw if equal
            {
                Console.WriteLine("Draw!");
            }
            else if (((int)user.RPS == 1 && (int)opponent.RPS == 3) || ((int)user.RPS == 2 && (int)opponent.RPS == 1) || ((int)user.RPS == 3 && (int)opponent.RPS == 2))    //Checks for all user win situations
            {
                user.TotalWins++;
                Console.WriteLine($"{userName} Wins!!!");
            }
            else
            {
                opponent.TotalWins++;
                Console.WriteLine($"{opponentName} Wins!!!");   //Otherwise YOU LOSE!
            }
            Console.WriteLine();
            Console.WriteLine($"Total wins - {user.Name} = {user.TotalWins} | {opponent.Name} = {opponent.TotalWins}\n");   //Displays total wins (stored in Player class as "TotalWins")
        }
    }
}
