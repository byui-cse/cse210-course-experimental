using System.Numerics;


namespace Byui.Games.Casting
{
    public class Polygon : Shape
    {
        private float _radius = 0f;
        private float _rotation = 0f;
        private int _sides = 0;
        
        public Polygon() { }

        public Polygon Copy()
        {
            Polygon polygon = new Polygon();
            polygon.SetColor(GetColor().Copy());
            polygon.SetFilled(IsFilled());
            polygon.SetPosition(GetPosition());
            polygon.SetRadius(GetRadius());
            polygon.SetRotation(GetRotation());
            polygon.SetSides(GetSides());
            polygon.SetVelocity(GetVelocity());
            return polygon;
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

        public float GetRotation()
        {
            return _rotation;
        }

        public int GetSides()
        {
            return _sides;
        }

        public float GetTop()
        {
            return GetPosition().Y - _radius;
        }

        public void SetRadius(float radius)
        {
            Validator.CheckGreaterThan(radius, 0);
            _radius = radius;
        }

        public void SetRotation(float degrees)
        {
            _rotation = degrees;
        }

        public void SetSides(int sides)
        {
            Validator.CheckGreaterThan(sides, 0);
            _sides = sides;
        }
    }
}