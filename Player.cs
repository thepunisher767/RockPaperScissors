namespace RockPaperScissors
{
    abstract class Player
    {
        public string Name { get; set; }
        public Roshambo RPS { get; set; }
        public int TotalWins { get; set; }
        public abstract Roshambo GenerateRoshambo();
    }
}
