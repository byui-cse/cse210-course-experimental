using System.Numerics;


namespace Byui.Games.Casting
{
    public class Rectangle : Shape
    {
        private Vector2 _size = Vector2.Zero;
        
        public Rectangle() { }

        public Rectangle Copy()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.SetColor(GetColor().Copy());
            rectangle.SetFilled(IsFilled());
            rectangle.SetPosition(GetPosition());
            rectangle.SetSize(GetSize());
            rectangle.SetVelocity(GetVelocity());
            return rectangle;
        }

        public float GetBottom()
        {
            return GetPosition().Y + _size.Y;
        }

        public float GetHeight()
        {
            return _size.Y;
        }

        public float GetLeft()
        {
            return GetPosition().X;
        }

        public Vector2 GetSize()
        {
            return _size;
        }

        public float GetRight()
        {
            return GetPosition().X + _size.X;
        }

        public float GetTop()
        {
            return GetPosition().Y;
        }

        public float GetWidth()
        {
            return _size.X;
        }

        public void SetSize(Vector2 size)
        {
            _size = size;
        }
    }
}