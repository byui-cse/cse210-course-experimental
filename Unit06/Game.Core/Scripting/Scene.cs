using Byui.Game.Casting;


namespace Byui.Game.Scripting
{
    /// <summary>
    /// The current state of the game.
    /// </summary>
    public class Scene
    {
        private double _alpha;
        private Cast _cast;
        private Script _script;
        
        public Scene(Cast cast, Script script)
        {
            _cast = cast;
            _script = script;
            _alpha = 0D;
        }

        public double GetAlpha()
        {
            return _alpha;
        }

        public Cast GetCast()
        {
            return _cast;
        }

        public Script GetScript()
        {
            return _script;
        }

        public void SetAlpha(double alpha)
        {
            _alpha = alpha;
        }
    }
}