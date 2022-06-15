using System;
using System.Numerics;
using Byui.Games.Casting;


namespace Example.Breaker.Game
{
    public class Paddle : Byui.Games.Casting.Image
    {
        private Ball _ball;
        
        public Paddle() { }

        public bool HasBall()
        {
            return _ball != null;
        }

        public override void Move()
        {
            base.Move();
            if (_ball != null)
            {
                float x = this.GetCenterX() - _ball.GetWidth() / 2;
                float y = this.GetTop() - _ball.GetHeight();
                _ball.MoveTo(x, y);
            }
        }

        public void AttachBall(Ball ball)
        {
            _ball = ball;
        }

        public void ReleaseBall()
        {
            _ball = null;
        }
    }
}