using System;
using System.Diagnostics;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Example.Scenes.Over;

namespace Example.Scenes.Game
{
    /// <summary>
    /// Loads the next scene after five seconds have passed.
    /// </summary>
    public class LoadSceneAction : Byui.Games.Scripting.Action
    {
        private SceneLoader _overSceneLoader;
        private Stopwatch _stopwatch;

        public LoadSceneAction(IServiceFactory serviceFactory)
        {
            _overSceneLoader = new OverSceneLoader(serviceFactory);
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors from the cast
                Label instructions = scene.GetFirstActor<Label>("instructions");

                // update the instructions with the time remaining
                int remainingSeconds = 5 - _stopwatch.Elapsed.Seconds;
                string newInstructions = $"game over in {remainingSeconds} seconds";
                instructions.Display(newInstructions);
                
                // load the next scene if five seconds have elapsed
                if (_stopwatch.Elapsed.Seconds >= 5)
                {
                    _stopwatch.Stop();
                    _overSceneLoader.Load(scene);
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't load scene.", exception);
            }
        }
    }
}