namespace Byui.Game.Casting
{
    /// <summary>
    /// An audio asset that is longer than ~10s.
    /// </summary>
    public class Music
    {
        private string _file = string.Empty;
        private bool _repeat = false;

        public Music(string file)
        {
            _file = file;
        }

        public Music(string file, bool repeat)
        {
            _file = file;
            _repeat = repeat;
        }

        public string GetFile()
        {
            return _file;
        }

        public bool IsRepeated()
        {
            return _repeat;
        }
    }
}