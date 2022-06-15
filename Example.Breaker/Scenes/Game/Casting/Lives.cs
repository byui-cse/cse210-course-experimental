using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Byui.Games.Casting;


namespace Example.Breaker.Game
{
    public class Lives : Byui.Games.Casting.Label
    {
        private int _lives = 0;
        
        public Lives(int lives) 
        {
            _lives = lives;
        }

        public override string GetText()
        {
            return $"LIVES: {_lives:00}";
        }

        public void AddLife()
        {
            _lives += 1;
        }

        public bool IsAlive()
        {
            return _lives > 0;
        }

        public bool IsDead()
        {
            return _lives <= 0;
        }

        public void RemoveLife()
        {
            _lives -= 1;
        }

    }
}
