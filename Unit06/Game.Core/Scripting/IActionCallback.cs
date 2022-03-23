namespace Byui.Game.Scripting 
{
    /// <summary>
    /// Receives action events.
    /// </summary>
    public interface IActionCallback
    {
        /// <summary>
        /// Invoked when an Action needs to signal a transition to the next Scene.
        /// </summary>
        /// <param name="scene">The next Scene.</param>
        void OnNextScene(Scene scene);

        /// <summary>
        /// Invoked when an Action needs to signal the game should be stopped.
        /// </summary>
        void OnStopGame();
    }
}