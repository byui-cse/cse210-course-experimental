using System.Numerics;


namespace Byui.Games.Casting
{
    public class Line
    {
        private Color _color = Color.White();
        private Vector2 _end = Vector2.Zero;
        private Vector2 _start = Vector2.Zero;
        
        public Line() { }

        public Color GetColor()
        {
            return _color;
        }

        public Vector2 GetEnd()
        {
            return _end;
        }

        public Vector2 GetStart()
        {
            return _start;
        }

        public void SetColor(Color color)
        {
            Validator.CheckNotNull(color);
            _color = color;
        }

        public void SetEnd(Vector2 end)
        {
            _end = end;
        }

        public void SetStart(Vector2 start)
        {
            _start = start;
        }
    }
}