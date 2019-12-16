namespace Katacombs.Zones
{
    public interface IZone
    {
        string[] ZoneOverview();
        string Look(Direction direction);
        IZone Open(string door);
    }
}