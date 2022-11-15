using System;
using System.Collections.Generic;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Breaker.Game
{
    public class CollideActorsAction : Byui.Games.Scripting.Action
    {
        private IAudioService _audioService;
        private ISettingsService _settingsService;

        public CollideActorsAction(IServiceFactory serviceFactory) 
        {
            _audioService = serviceFactory.GetAudioService();
            _settingsService = serviceFactory.GetSettingsService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                DoBallPaddleCollision(scene);
                DoBallBottomCollision(scene);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move actors.", exception);
            }
        }

        private void DoBallBottomCollision(Scene scene)
        {
            Paddle paddle = scene.GetFirstActor<Paddle>("paddle");
            List<Ball> balls = scene.GetAllActors<Ball>("balls");
            Actor field = scene.GetFirstActor("field");
            Lives lives = scene.GetFirstActor<Lives>("lives");

            foreach (Ball ball in balls)
            {
                if (ball.GetBottom() >= field.GetBottom())
                {
                    if (balls.Count == 1)
                    {
                        paddle.AttachBall(ball);
                        string sound = _settingsService.GetString("startSound");
                        _audioService.PlaySound(sound);
                        lives.RemoveLife();
                    }
                    else
                    {
                        scene.RemoveActor("balls", ball);
                    }
                }
            }
        }

        private void DoBallPaddleCollision(Scene scene)
        {
            Paddle paddle = scene.GetFirstActor<Paddle>("paddle");
            List<Ball> balls = scene.GetAllActors<Ball>("balls");
            
            foreach(Ball ball in balls)
            {
                if (ball.Overlaps(paddle))
                {
                    ball.BounceY();
                    string sound = _settingsService.GetString("bounceSound");
                    _audioService.PlaySound(sound);
                }
            }
        }

        // private void DoSpecialPaddleCollision(Scene scene)
        // {
        //     Paddle paddle = scene.GetFirstActor<Paddle>("paddle");
        //     List<Special> specials = scene.GetAllActors<Special>("specials");
            
        //     foreach(Special special in specials)
        //     {
        //         if (paddle.Overlaps(special))
        //         {
        //             Action effect = special.GetEffect();
        //             effect.Execute(scene, 0f, null);
        //             scene.RemoveActor("specials", special);
        //         }
        //     }
        // }

        // private void DoSpecialBottomCollision(Scene scene)
        // {
        //     Actor field = scene.GetFirstActor("field");
        //     List<Special> specials = scene.GetAllActors<Special>("specials");
        //     foreach(Special special in specials)
        //     {
        //         if (special.GetBottom() >= field.GetBottom())
        //         {
        //             scene.RemoveActor("specials", special);
        //         }
        //     }
        // }

        
    }
}