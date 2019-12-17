namespace Katacombs.Player
{
    public interface IPlayer
    {
        Message ZoneOverview();
        Message Look(string option);
        Message Open(string door);
        Message Take(string item);
        Message Bag();
        Message Go(Direction direction);
        Message Use(string whiteKey);
    }
}