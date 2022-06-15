using System;
using Byui.Games.Casting;


namespace Example.Breaker.Game
{
    public class Score : Byui.Games.Casting.Label
    {
        private int _points = 0;
        
        public Score() { }

        public override string GetText()
        {
            return $"SCORE: {_points:000000000}";
        }

        public void AddPoints(int points)
        {
            _points += points;
        }

    }
}
