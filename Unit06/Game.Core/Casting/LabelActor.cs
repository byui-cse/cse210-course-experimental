using System;


namespace Byui.Game.Casting
{
    /// <summary>
    /// A readable participant in the game.
    /// </summary>
    public abstract class LabelActor : Actor
    {
        public static readonly int Center = 0;
        public static readonly int Left = 1;
        public static readonly int Right = 2;
        
        private string _font = string.Empty;
        private int _fontSize = 0;
        private string _text = string.Empty;
        private int _alignment = Left;
        private Color _color = Color.White;

        public LabelActor()
        {
        }

        public Color GetColor()
        {
            return _color;
        }

        public string GetFont()
        {
            return _font;
        }

        public int GetFontSize()
        {
            return _fontSize;
        }

        public int GetAlignment()
        {
            return _alignment;
        }

        public string GetText()
        {
            return _text;
        }

        public void Align(int alignment)
        {
            if (alignment != Left && alignment != Right && alignment != Center)
            {
                throw new ArgumentException("Alignment must be one of Left(0), Right(1) or Center(2).");
            }
            _alignment = alignment;
        }

        public void Display(string text)
        {
            _text = text;
        }

        public void SetColor(Color color)
        {
            _color = color;
        }

        public void UseFont(string font, int fontSize)
        {
            _font = font;
            _fontSize = fontSize;
        }

    }
}