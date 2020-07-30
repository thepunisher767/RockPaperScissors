using System;

namespace RockPaperScissors
{
    class HumanPlayer : Player
    {
        public override Roshambo GenerateRoshambo()
        {
            Console.Clear();
            Console.Write("Please enter (1)rock, (2)paper, or (3)scissors: ");
            Roshambo result = Validation.RPSInput(Console.ReadLine().ToLower());   //Validates user input through Validation class below
            return result;
        }
    }
}
