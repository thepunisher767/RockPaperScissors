using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace RockPaperScissors
{

    enum Roshambo
    { 
        rock = 1,
        paper,
        scissors
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock Paper Scissors!!!\n");
            Player user = new HumanPlayer();
            user.Name = Validation.GetName();
            Player opponent = Validation.GetOpponent();
            bool continueFlag = true;
            while (continueFlag)
            {           
                user.RPS = user.GenerateRoshambo();
                opponent.RPS = opponent.GenerateRoshambo();
                Validation.RPSOutcome(user, opponent, user.Name, opponent.Name);
                Console.Write("Play again? (y/n): ");
                Validation.YesOrNo(Console.ReadLine(), ref continueFlag);
            }
            Console.WriteLine($"\nOK BYEEEEEEEEEEEEE!!!!!!\n");
        }
    }
}
