using System;
using System.Numerics;
using Byui.Games.Casting;


namespace Example.Breaker.Game
{
    public class Ball : Byui.Games.Casting.Image
    {
        public Ball() { }

        public void BounceX()
        {
            Vector2 velocity = GetVelocity();
            float x = velocity.X *= -1;
            float y = velocity.Y;
            Vector2 direction = new Vector2(x, y);
            Steer(direction);
        }

        public void BounceY()
        {
            Vector2 velocity = GetVelocity();
            float x = velocity.X;
            float y = velocity.Y *= -1;
            Vector2 direction = new Vector2(x, y);
            Steer(direction);
        }

    }
}
