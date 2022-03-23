namespace Byui.Game.Casting
{
    public class Color
    {
        public static readonly Color Black = new Color();
        public static readonly Color Blue = new Color(0, 0, 255);
        public static readonly Color Green = new Color(0, 255, 0);
        public static readonly Color Orange = new Color(255, 128, 0);
        public static readonly Color Purple = new Color(255, 0, 255);
        public static readonly Color Red = new Color(255, 0, 0);
        public static readonly Color Yellow = new Color(255, 255, 0);
        public static readonly Color White = new Color();
        
        private int _r = 255;
        private int _g = 255;
        private int _b = 255;
        private int _a = 255;

        public Color()
        {
        }

        public Color(int r, int g, int b)
        {
            _r = r;
            _g = g;
            _b = b;
        }

        public Color(int r, int g, int b, int a)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = a;
        }

        public int GetA()
        {
            return _a;
        }

        public int GetB()
        {
            return _b;
        }

        public int GetG()
        {
            return _g;
        }

        public int GetR()
        {
            return _r;
        }

        public override string ToString()
        {
            return $"Color (r: {_r}, g: {_g}, b: {_b}, a: {_a})";
        }
    }
}