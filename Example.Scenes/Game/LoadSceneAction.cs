using System;
using System.Diagnostics;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Example.Scenes.Over;

namespace Example.Scenes.Game
{
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
                Label instructions = scene.GetFirstActor<Label>("instructions");
                int remainingSeconds = 5 - _stopwatch.Elapsed.Seconds;
                instructions.Display($"game over in {remainingSeconds} seconds");
                
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