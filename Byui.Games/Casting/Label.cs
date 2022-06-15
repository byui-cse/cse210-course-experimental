namespace Byui.Games.Casting
{
    /// <summary>
    /// A readable Actor.
    /// </summary>
    /// <remarks>
    /// The responssibility of Text is to define the textual appearance of an Actor.
    /// </remarks>
    public class Label : Actor
    {
        public const int Left = 0;
        public const int Center = 1;
        public const int Right = 2;
        
        private int _alignment = Left;
        private Color _fontColor = Color.White();
        private string _fontFile = string.Empty;
        private float _fontSize = 18f;
        private string _text = string.Empty;
        
        public Label() {}

        public void Align(int alignment)
        {
            Validator.CheckInRange(alignment, Left, Right);
            _alignment = alignment;
        }

        public void Display(string text)
        {
            Validator.CheckNotBlank(text);
            _text = text;
        }

        public int GetAlignment()
        {
            return _alignment;
        }

        public Color GetFontColor()
        {
            return _fontColor;
        }

        public string GetFontFile()
        {
            return _fontFile;
        }

        public float GetFontSize()
        {
            return _fontSize;
        }

        public virtual string GetText()
        {
            return _text;
        }

        public void SetFont(string file, float size, Color color)
        {
            Validator.CheckNotNull(file);
            Validator.CheckGreaterThan(size, 0);
            Validator.CheckNotNull(color);
            _fontFile = file;
            _fontSize = size;
            _fontColor = color;
        }
    }
}