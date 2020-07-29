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
        public abstract Roshambo GenerateRoshambo();
    }

    class RockMan : Player
    {
        public override Roshambo GenerateRoshambo()
        {
            Roshambo result = Roshambo.rock;
            return result;
        }
    }

    class RandomMan : Player
    {
        Random random = new Random();
        public override Roshambo GenerateRoshambo()
        {
            Array rpsValues = Enum.GetValues(typeof(Roshambo));
            Roshambo result = (Roshambo)rpsValues.GetValue(random.Next(rpsValues.Length));
            return result;
        }
    }

    class HumanPlayer : Player
    {
        public override Roshambo GenerateRoshambo()
        {
            Console.Write("Please enter (1)rock, (2)paper, or (3)scissors: ");
            string userInput = Console.ReadLine();
            Roshambo result = Validation.RPSInput(userInput);
            return result;
        }
    }

    class Validation
    {
        public static Roshambo RPSInput(string userInput)   //This seems good, but will need to adjust later
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

        public static bool YesOrNo(string userInput) //Also seems good, but will need to adjust
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

        public static string GetName()
        {
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();
            return userName;
        }

        public static Player GetOpponent()
        {
            Console.Write("Who would you like to play against? (Phil or Jimbo): ");
            string userChoice = Console.ReadLine();
            while (userChoice.ToLower() != "phil" && userChoice.ToLower() != "jimbo")
            {
                Console.Write("Please enter a valid opponent (Phil or Jimbo): ");
                userChoice = Console.ReadLine();
            }
            if (userChoice.ToLower() == "phil")
            {
                RockMan Phil = new RockMan();
                Phil.Name = "Phil";
                return Phil;
            }
            else
            {
                RandomMan Jimbo = new RandomMan();
                Jimbo.Name = "Jimbo";
                return Jimbo;
            }
            Console.WriteLine();
        }
        public static void RPSOutcome(Roshambo user, Roshambo opponent, string userName, string opponentName)
        {
            Console.WriteLine($"\n{userName}: {user}");
            Console.WriteLine($"{opponentName}: {opponent}");
            if (user == opponent)
            {
                Console.WriteLine("Draw!");
            }
            else if (((int)user == 1 && (int)opponent == 3) || ((int)user == 2 && (int)opponent == 1) || ((int)user == 3 && (int)opponent == 2))
            {
                Console.WriteLine($"{userName} Wins!!!");
            }
            else
            {
                Console.WriteLine($"{opponentName} Wins!!!");
            }
            Console.WriteLine();
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
                Validation.RPSOutcome(user.RPS, opponent.RPS, user.Name, opponent.Name);
                Console.Write("Play again? (y/n): ");
                continueFlag = Validation.YesOrNo(Console.ReadLine());
            }
        }
    }
}
