namespace Byui.Game.Scripting
{
    /// <summary>
    /// The distinct stage of the game loop.
    /// </summary>
    public class Phase
    {
        public static readonly int None = 0;
        public static readonly int Initialize = 1;
        public static readonly int Load = 2;
        public static readonly int Input = 4;
        public static readonly int Update = 7;
        public static readonly int Output = 10;
        public static readonly int Unload = 12;
        public static readonly int Release = 13;

        private Phase() { }
    }
}