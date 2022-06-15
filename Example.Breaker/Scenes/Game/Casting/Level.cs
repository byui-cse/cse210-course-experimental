using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Byui.Games.Casting;


namespace Example.Breaker.Game
{
    public class Level : Byui.Games.Casting.Label
    {
        private int _level = 1;
        
        public Level() { }

        public override string GetText()
        {
            return $"LEVEL: {_level:000}";
        }

        public void Increment()
        {
            _level += 1;
        }

    }
}
