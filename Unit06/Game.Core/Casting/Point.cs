using System;


namespace Byui.Game.Casting
{
    /// <summary>
    /// A distance from a relative origin.
    /// </summary>
    public class Point
    {
        private int _x = 0;
        private int _y = 0;

        public Point()
        {
        }

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Point Add(Point other)
        {
            int x = _x + other.GetX();
            int y = _y + other.GetY();
            return new Point(x, y);
        }

        public Point DivideBy(int factor)
        {
            int x = _x / factor;
            int y = _y / factor;
            return new Point(x, y);
        }

        public override bool Equals(object other)
        {
            return Equals(other as Point);
        }

        public bool Equals(Point other)
        {
            return _x == other.GetX() && _y == other.GetY();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_x, _y);
        }

        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _y;
        }

        public Point Invert()
        {
            int x = _x * -1;
            int y = _y * -1;
            return new Point(x, y);
        }

        public Point MultiplyBy(double factor)
        {
            int x = (int)(_x * factor);
            int y = (int)(_y * factor);
            return new Point(x, y);
        }

        public Point Subtract(Point other)
        {
            int x = _x - other.GetX();
            int y = _y - other.GetY();
            return new Point(x, y);
        }

        public override string ToString()
        {
            return $"(x: {_x}, y: {_y})";
        }
    }
}