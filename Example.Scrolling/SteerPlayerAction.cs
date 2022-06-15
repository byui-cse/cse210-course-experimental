using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Scrolling
{
    public class SteerPlayerAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;

        public SteerPlayerAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                int directionX = 0;
                int directionY = 0;

                if (_keyboardService.IsKeyDown(KeyboardKey.W))
                {
                    directionY = -5;
                }
                else if (_keyboardService.IsKeyDown(KeyboardKey.S))
                {
                    directionY = 5;
                }

                if (_keyboardService.IsKeyDown(KeyboardKey.A))
                {
                    directionX = -5;
                }
                else if (_keyboardService.IsKeyDown(KeyboardKey.D))
                {
                    directionX = 5;
                }

                Actor player = scene.GetFirstActor("player");
                player.Steer(directionX, directionY);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't steer actor.", exception);
            }
        }
    }
}