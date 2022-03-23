namespace Byui.Game.Casting
{
    /// <summary>
    /// An audio asset that is shorter than ~10s.
    /// </summary>
    public class Sound
    {
        private string _file = string.Empty;

        public Sound(string file)
        {
            _file = file;
        }

        public string GetFile()
        {
            return _file;
        }
    }
}