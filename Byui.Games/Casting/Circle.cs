using System.Numerics;


namespace Byui.Games.Casting
{
    public class Circle : Shape
    {
        private float _radius = 0f;
        
        public Circle() { }

        public Circle Copy()
        {
            Circle circle = new Circle();
            circle.SetColor(GetColor().Copy());
            circle.SetFilled(IsFilled());
            circle.SetPosition(GetPosition());
            circle.SetRadius(GetRadius());
            circle.SetVelocity(GetVelocity());
            return circle;
        }

        public float GetBottom()
        {
            return GetPosition().Y + _radius;
        }

        public float GetDiameter()
        {
            return _radius * 2;
        }

        public float GetLeft()
        {
            return GetPosition().X - _radius;
        }
        
        public float GetRadius()
        {
            return _radius;
        }

        public float GetRight()
        {
            return GetPosition().X + _radius;
        }

        public float GetTop()
        {
            return GetPosition().Y - _radius;
        }

        public void SetRadius(float radius)
        {
            _radius = radius;
        }

    }
}