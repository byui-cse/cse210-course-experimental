using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Breaker.Game
{
    public class SteerActorsAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;
        private ISettingsService _settingsService;

        public SteerActorsAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
            _settingsService = serviceFactory.GetSettingsService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                ReleaseBall(scene);
                SteerPaddle(scene);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't steer paddle.", exception);
            }
        }

        private void ReleaseBall(Scene scene)
        {
            Paddle paddle = scene.GetFirstActor<Paddle>("paddle");
            if (paddle.HasBall() && _keyboardService.IsKeyDown(KeyboardKey.Space))
            {
                paddle.ReleaseBall();
            }
        }

        private void SteerPaddle(Scene scene)
        {
            float directionX = 0;
            float directionY = 0;

            if (_keyboardService.IsKeyDown(KeyboardKey.Left))
            {
                directionX = _settingsService.GetFloat("paddleVelocity") * -1;
            }
            else if (_keyboardService.IsKeyDown(KeyboardKey.Right))
            {
                directionX = _settingsService.GetFloat("paddleVelocity");
            }

            Paddle paddle = scene.GetFirstActor<Paddle>("paddle");
            paddle.Steer(directionX, directionY);
        }
    }
}