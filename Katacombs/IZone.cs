namespace Katacombs
{
    public interface IZone
    {
        string[] ZoneOverview();
        string Look(Direction direction);
    }
}