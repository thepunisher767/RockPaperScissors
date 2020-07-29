using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace RockPaperScissors
{

    enum Roshambo
    { 
        rock = 1,
        paper,
        scissors
    }

    abstract class Player
    {
        public string Name { get; set; }
        public Roshambo RPS { get; set; }
        public int TotalWins { get; set; }
        public abstract Roshambo GenerateRoshambo();
    }

    class RockMan : Player
    {
        public override Roshambo GenerateRoshambo()
        {
            Roshambo result = Roshambo.rock;    //Always gonna be rock
            return result;
        }
    }

    class RandomMan : Player
    {
        Random random = new Random();
        public override Roshambo GenerateRoshambo()
        {
            Array rpsValues = Enum.GetValues(typeof(Roshambo)); //Sets all the emun values to an array to help generate random below
            Roshambo result = (Roshambo)rpsValues.GetValue(random.Next(rpsValues.Length));  //Generate random Roshambo value
            return result;
        }
    }

    class HumanPlayer : Player
    {
        public override Roshambo GenerateRoshambo()
        {
            Console.Clear();
            Console.Write("Please enter (1)rock, (2)paper, or (3)scissors: ");
            string userInput = Console.ReadLine();
            Roshambo result = Validation.RPSInput(userInput);   //Validates user input through Validation class below
            return result;
        }
    }

    class Validation
    {
        public static Roshambo RPSInput(string userInput)   //Check for valid user input
        {
            userInput = userInput.ToLower();
            Roshambo result = 0;
            string[] acceptedInput = { "r", "p", "s", "rock", "paper", "scissors", "1", "2", "3" };
            while (!acceptedInput.Contains(userInput))
            {
                Console.Write("Please enter valid input. (1)rock, (2)paper, (3) scissors: ");
                userInput = Console.ReadLine().ToLower();
            }
            if (userInput == "r" || userInput == "rock" || userInput == "1")
            {
                result = (Roshambo)1;
            }
            else if (userInput == "p" || userInput == "paper" || userInput == "2")
            {
                result = (Roshambo)2;
            }
            else if (userInput == "s" || userInput == "scissors" || userInput == "3")
            {
                result = (Roshambo)3;
            }
            return result;
        }

        public static bool YesOrNo(string userInput) //Checks to continue or not and returns bool
        {
            bool continueFlag = true;
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
            string userChoice = Console.ReadLine();
            while (userChoice.ToLower() != "phil" && userChoice.ToLower() != "adom")    //Makes sure input is valid
            {
                Console.Write("Please enter a valid opponent (Phil or Adom): ");
                userChoice = Console.ReadLine();
            }
            if (userChoice.ToLower() == "phil") //Make a Phil!
            {
                RockMan Phil = new RockMan();
                Phil.Name = "Phil";
                Console.WriteLine();
                return Phil;
            }
            else
            {
                RandomMan Adom = new RandomMan();   //Make an Adom!
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

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock Paper Scissors!!!\n");
            HumanPlayer user = new HumanPlayer();
            user.Name = Validation.GetName();
            Player opponent = Validation.GetOpponent();
            bool continueFlag = true;
            while (continueFlag)
            {           
                user.RPS = user.GenerateRoshambo();
                opponent.RPS = opponent.GenerateRoshambo();
                Validation.RPSOutcome(user, opponent, user.Name, opponent.Name);
                Console.Write("Play again? (y/n): ");
                continueFlag = Validation.YesOrNo(Console.ReadLine());
            }
            Console.WriteLine($"\nOK BYEEEEEEEEEEEEE!!!!!!\n");
        }
    }
}
