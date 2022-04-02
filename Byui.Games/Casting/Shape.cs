using System.Numerics;


namespace Byui.Games.Casting
{
    public abstract class Shape : Actor
    {
        private Vector2 _position = Vector2.Zero;
        private Color _color = Color.White();
        private bool _filled = false;
        private Vector2 _velocity = Vector2.Zero;
        
        public Shape() { }

        public Color GetColor()
        {
            return _color;
        }

        public Vector2 GetPosition()
        {
            return _position;
        }

        public Vector2 GetVelocity()
        {
            return _velocity;
        }

        public bool IsFilled()
        {
            return _filled;
        }

        public void SetColor(Color color)
        {
            Validator.CheckNotNull(color);
            _color = color;
        }

        public void SetFilled(bool filled)
        {
            _filled = filled;
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }

        public void SetVelocity(Vector2 velocity)
        {
            _velocity = velocity;
        }
    }
}