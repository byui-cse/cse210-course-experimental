using System;
using System.Collections.Generic;
using Byui.Game.Scripting;


namespace Byui.Game.Directing
{
    /// <summary>
    /// Controls the sequence and pacing of the game.
    /// </summary>
    public class Director : IActionCallback
    {
        private static int DefaultFramesPerSecond = 60;
        
        private Clock _clock;
        private Scene _scene; 
        
        public Director(Scene scene)
        {
            _clock = new Clock(DefaultFramesPerSecond);
            _scene = scene;
        }

        public Director(Scene scene, int framesPerSecond)
        {
            _clock = new Clock(framesPerSecond);
            _scene = scene;
        }

        public void OnNextScene(Scene scene)
        {
            _scene = scene;
        }

        public void OnStopGame()
        {
            _clock.Stop();
        }

        public void StartGame()
        {
            _clock.Start();
            Execute(Phase.Initialize);
            Execute(Phase.Load);
            while (_clock.IsRunning())
            {
                _clock.AddTime();
                Execute(Phase.Input);
                while (_clock.HasTime())
                {
                    Execute(Phase.Update);
                    _clock.UseTime();
                }
                double alpha = _clock.GetAlpha();
                _scene.SetAlpha(alpha);
                Execute(Phase.Output);
            }
            Execute(Phase.Unload);
            Execute(Phase.Release);
        }

        private void Execute(int phase)
        {
            Script script = _scene.GetScript();
            List<IAction> actions = script.Get(phase);
            foreach(IAction action in actions)
            {
                action.Execute(_scene, this);
            }
        }

    }
}