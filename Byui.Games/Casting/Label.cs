namespace Byui.Games.Casting
{
    /// <summary>
    /// A readable Actor.
    /// </summary>
    /// <remarks>
    /// The responssibility of Text is to define the textual appearance of an Actor.
    /// </remarks>
    public class Label : Texture
    {
        public const int LeftAligned = 0;
        public const int CenterAligned = 1;
        public const int RightAligned = 2;
        
        private int _alignment = LeftAligned;
        private Font _font = new Font();
        private string _text = string.Empty;
        
        public Label() {}

        public int GetAlignment()
        {
            return _alignment;
        }

        public Font GetFont()
        {
            return _font;
        }

        public string GetText()
        {
            return _text;
        }

        public void SetAlignment(int alignment)
        {
            Validator.CheckInRange(alignment, LeftAligned, RightAligned);
            _alignment = alignment;
        }

        public void SetFont(Font font)
        {
            Validator.CheckNotNull(font);
            _font = font;
        }

        public void SetText(string text)
        {
            Validator.CheckNotBlank(text);
            _text = text;
        }
    }
}