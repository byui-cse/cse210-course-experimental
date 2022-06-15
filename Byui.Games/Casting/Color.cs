using System;

namespace Byui.Games.Casting
{
    /// <summary>
    /// A color.
    /// </summary>
    public class Color
    {
        public static Color Black() { return new Color(0, 0, 0); }
        public static Color Red() { return new Color(255, 0, 0); }
        public static Color Orange() { return new Color(255, 128, 0); }
        public static Color Yellow() { return new Color(255, 255, 0); }
        public static Color Green() { return new Color(0, 255, 0); }
        public static Color Blue() { return new Color(0, 128, 255); }
        public static Color Purple() { return new Color(127, 0, 255); }
        public static Color White() { return new Color(255, 255, 255); }
        public static Color Gray() { return new Color(128, 128, 128); }

        private byte _red = 0;
        private byte _green = 0;
        private byte _blue = 0;
        private byte _alpha = 0;

        public Color(byte red, byte green, byte blue, byte alpha = 255)
        {
            _red = red;
            _green = green;
            _blue = blue;
            _alpha = alpha;
        }

        public Color Copy()
        {
            return new Color(_red, _green, _blue, _alpha);
        }

        public Tuple<byte, byte, byte, byte> ToTuple()
        {
            return Tuple.Create(_red, _green, _blue, _alpha);
        }
    }
}