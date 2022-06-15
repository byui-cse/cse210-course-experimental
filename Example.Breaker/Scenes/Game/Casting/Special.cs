using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;


namespace Example.Breaker.Game
{
    public class Special : Byui.Games.Casting.Image
    {
        private Action _effect;

        public Special(Action effect) 
        {
            _effect = effect;
        }

        public Action GetEffect()
        {
            return _effect;
        }

    }
}