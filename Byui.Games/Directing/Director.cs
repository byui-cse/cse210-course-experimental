using System.Collections.Generic;
using Byui.Games.Scripting;
using Byui.Games.Services;

namespace Byui.Games.Directing
{
    /// <summary>
    /// Controls the sequence and pacing of the game.
    /// </summary>
    public class Director : IActionCallback
    {
        private IAudioService _audioService = null;
        private IVideoService _videoService = null;
        
        public Director(IServiceFactory serviceFactory)
        {
            _audioService = serviceFactory.GetAudioService();
            _videoService = serviceFactory.GetVideoService();
        }

        public void OnError(string message, System.Exception exception)
        {
            _audioService.Release();
            _videoService.Release();
            System.Console.Error.WriteLine($"ERROR: {message}");
            System.Console.Error.WriteLine(exception.Message);
            System.Console.Error.WriteLine(exception.StackTrace);
        }

        public void OnInfo(string message)
        {
            System.Console.Out.WriteLine($"INFO: {message}");
        }

        public void OnStop()
        {
            _audioService.Release();
            _videoService.Release();
        }

        public void OnWarning(string message)
        {
            System.Console.Out.WriteLine($"WARNING: {message}");
        }

        public void Direct(Scene scene)
        {
            _audioService.Initialize();
            _videoService.Initialize();
            while (_videoService.IsWindowOpen())
            {
                DoActions(Phase.Input, scene);
                DoActions(Phase.Update, scene);
                DoActions(Phase.Output, scene);
                scene.ApplyChanges();
            }
            _audioService.Release();
            _videoService.Release();
        }

        private void DoActions(int phase, Scene scene)
        {
            float deltaTime = _videoService.GetDeltaTime();
            List<Action> actions = scene.GetAllActionsIn(phase);
            foreach(Action action in actions)
            {
                action.Execute(scene, deltaTime, this);
            }
        }
    }
}