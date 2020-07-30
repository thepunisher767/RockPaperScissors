namespace RockPaperScissors
{
    class RockMan : Player
    {
        public override Roshambo GenerateRoshambo()
        {
            Roshambo result = Roshambo.rock;    //Always gonna be rock
            return result;
        }
    }
}
