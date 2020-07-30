using System;

namespace RockPaperScissors
{
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
}
