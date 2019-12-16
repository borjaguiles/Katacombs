namespace Katacombs.Player
{
    public interface IPlayer
    {
        string[] ZoneOverview();
        string Look(string option);
        string[] Open(string door);
    }
}