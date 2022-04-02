using System.Numerics;


namespace Byui.Games.Casting
{
    /// <summary>
    /// A participant in the game.
    /// </summary>
    public abstract class Actor
    {
        private bool _enabled = true;

        public Actor() { }

        public bool IsEnabled()
        {
            return _enabled;
        }

        public void Disable()
        {
            _enabled = false;
        }

        public void Enable()
        {
            _enabled = true;
        } 
    }
}