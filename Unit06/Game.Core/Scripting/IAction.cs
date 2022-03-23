namespace Byui.Game.Scripting
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// Executes specific game logic by querying, inspecting, and changing actors or actions in
        /// the specifid scene.
        /// </summary>
        /// <param name="scene">The scene to query, inspect and/or change.</param>
        /// <param name="callback">A callback that receives action events.</param>
        void Execute(Scene scene, IActionCallback callback);
    }
}