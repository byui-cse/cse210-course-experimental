namespace Byui.Games.Casting
{
    /// <summary>
    /// A text font.
    /// </summary>
    public class Font
    {
        private Color _color = Color.White();
        private string _file = string.Empty;
        private float _size = 12f;
        
        public Font() { }

        public Color GetColor()
        {
            return _color;
        }

        public string GetFile()
        {
            return _file;
        }

        public float GetSize()
        {
            return _size;
        }

        public void SetColor(Color color)
        {
            Validator.CheckNotNull(color);
            _color = color;
        }

        public void SetFile(string file)
        {
            Validator.CheckNotBlank(file);
            _file = file;
        }

        public void SetSize(float size)
        {
            Validator.CheckGreaterThan(size, 0);
            _size = size;
        }
    }
}