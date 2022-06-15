using System;
using System.Collections.Generic;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Breaker.Game
{
    public class MoveActorsAction : Byui.Games.Scripting.Action
    {
        private IAudioService _audioService;
        private ISettingsService _settingsService;

        public MoveActorsAction(IServiceFactory serviceFactory) 
        {
            _audioService = serviceFactory.GetAudioService();
            _settingsService = serviceFactory.GetSettingsService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                MoveBalls(scene);
                MovePaddle(scene);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move actors.", exception);
            }
        }

        private void MoveBalls(Scene scene)
        {
            List<Ball> balls = scene.GetAllActors<Ball>("balls");
            Actor field = scene.GetFirstActor("field");
            foreach (Ball ball in balls)
            {
                ball.Move();
                if (ball.BounceIn(field))
                {
                    string sound = _settingsService.GetString("bounceSound");
                    _audioService.PlaySound(sound);
                }
            }
        }

        private void MovePaddle(Scene scene)
        {
            Paddle paddle = scene.GetFirstActor<Paddle>("paddle");
            Actor field = scene.GetFirstActor("field");
            paddle.Move();
            paddle.ClampTo(field);
        }
    }
}