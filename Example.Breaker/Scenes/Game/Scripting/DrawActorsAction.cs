using System;
using System.Collections.Generic;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Breaker.Game
{
    public class DrawActorsAction : Byui.Games.Scripting.Action
    {
        private IVideoService _videoService;

        public DrawActorsAction(IServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                
                _videoService.ClearBuffer();
                DrawBalls(scene);
                DrawPaddles(scene);
                DrawLevel(scene);
                DrawScore(scene);
                DrawLives(scene);
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }

        private void DrawBalls(Scene scene)
        {
            List<Ball> balls = scene.GetAllActors<Ball>("balls");
            foreach (Ball ball in balls)
            {
                _videoService.Draw(ball);
            }
        }

        private void DrawPaddles(Scene scene)
        {
            Paddle paddle = scene.GetFirstActor<Paddle>("paddle");
            _videoService.Draw(paddle);
        }

        private void DrawLevel(Scene scene)
        {
            Level level = scene.GetFirstActor<Level>("level");
            _videoService.Draw(level);
        }

        private void DrawLives(Scene scene)
        {
            Lives lives = scene.GetFirstActor<Lives>("lives");
            _videoService.Draw(lives);
        }

        private void DrawScore(Scene scene)
        {
            Score score = scene.GetFirstActor<Score>("score");
            _videoService.Draw(score);
        }
    }
}