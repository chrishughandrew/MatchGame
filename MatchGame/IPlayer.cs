namespace MatchGame
{
    public interface IPlayer
    {
        int Score { get; set; }
        void AddPoints(int points);
    }
}