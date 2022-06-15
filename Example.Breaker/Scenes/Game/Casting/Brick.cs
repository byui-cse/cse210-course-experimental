using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;


namespace Example.Breaker.Game
{
    public class Brick : Byui.Games.Casting.Image
    {
        private Special _special;

        public Special() 
        {
        }

        public Special(Special special) 
        {
            _special = special;
        }

        public Special GetSpecial()
        {
            return _special;
        }

        public bool HasSpecial()
        {
            return _special != null;
        }

    }
}