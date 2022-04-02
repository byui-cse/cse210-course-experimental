using System.Numerics;


namespace Byui.Games.Casting
{
    public abstract class Texture : Actor
    {
        private Vector2 _position = Vector2.Zero;
        private Vector2 _size = Vector2.Zero;
        private Color _tint = Color.White();
        private Vector2 _velocity = Vector2.Zero;
        
        public Texture() { }

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
        
        public Vector2 GetPosition()
        {
            return _position;
        }

        public float GetRight()
        {
            return GetPosition().X + _size.X;
        }

        public Vector2 GetSize()
        {
            return _size;
        }

        public Color GetTint()
        {
            return _tint;
        }

        public float GetTop()
        {
            return GetPosition().Y;
        }

        public Vector2 GetVelocity()
        {
            return _velocity;
        }

        public float GetWidth()
        {
            return _size.X;
        }

        public void SetSize(Vector2 size)
        {
            _size = size;
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }

        public void SetTint(Color tint)
        {
            Validator.CheckNotNull(tint);
            _tint = tint;
        }

        public void SetVelocity(Vector2 velocity)
        {
            _velocity = velocity;
        }
    }
}