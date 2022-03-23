using System;


namespace Byui.Game.Casting
{
    /// <summary>
    /// A movable, collidable participant in the game.
    /// </summary>
    public abstract class Actor
    {
        private Point _previous = new Point();
        private Point _position = new Point();
        private int _rotation = 0;
        private Point _size = new Point();
        private Point _velocity = new Point();

        public Actor()
        {
        }

        public int GetBottom()
        {
            return _position.GetY() + _size.GetY();
        }

        public int GetLeft()
        {
            return _position.GetX();
        }

        public Point GetPosition()
        {
            return _position;
        }

        public int GetRight()
        {
            return _position.GetX() + _size.GetX();
        }

        public int GetRotation()
        {
            return _rotation;
        }

        public Point GetSize()
        {
            return _size;
        }

        public int GetTop()
        {
            return _position.GetY();
        }

        public Point GetVelocity()
        {
            return _velocity;
        }

        public Point Interpolate(double alpha)
        {
            Point a = _position.MultiplyBy(alpha);
            Point b = _previous.MultiplyBy(1.0 - alpha);
            return a.Add(b);
        }

        public bool IsAbove(Actor other)
        {
            return this.GetTop() < other.GetTop();
        }

        public bool IsBelow(Actor other)
        {
            return this.GetBottom() > other.GetBottom();
        }

        public bool IsLeftOf(Actor other)
        {
            return this.GetLeft() < other.GetLeft();
        }

        public bool IsOverlapping(Actor other)
        {
            return (this.GetLeft() < other.GetRight()
                && this.GetRight() > other.GetLeft()
                && this.GetTop() < other.GetBottom()
                && this.GetBottom() > other.GetTop());
        }

        public bool IsRightOf(Actor other)
        {
            return this.GetRight() > other.GetRight();
        }

        public void Move()
        {
            _previous = _position;
            _position = _position.Add(_velocity);
        }

        public void MoveTo(Point position)
        {
            _position = position;
        }

        public void Resize(int width, int height)
        {
            _size = new Point(width, height);
        }

        public void Rotate(int degrees)
        {
            _rotation = degrees;
        }

        public void Scale(double factor)
        {
            _size = _size.MultiplyBy(factor);
        }

        public void Steer(Point velocity)
        {
            _velocity = velocity;
        }
    }
}