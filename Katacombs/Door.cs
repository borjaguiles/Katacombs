namespace Katacombs
{
    public class Door
    {
        private readonly Direction _direction;
        private readonly string _doorName;
        private readonly string _keyName;

        public Door(Direction direction, string doorName, string keyName = null)
        {
            _direction = direction;
            _doorName = doorName;
            _keyName = keyName;
        }

        public bool NameIs(string doorName)
        {
            return _doorName == doorName;
        }

        public bool IsUnlocked()
        {
            return string.IsNullOrWhiteSpace(_keyName);
        }
    }
}