using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Scrolling
{
    /// <summary>
    /// Steers the player left, right, up or down based on keyboard input.
    /// </summary>
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
                // declare basic speed and direction variables
                int playerSpeed = 5;
                int directionX = 0;
                int directionY = 0;

                // detect vertical or y-axis direction
                if (_keyboardService.IsKeyDown(KeyboardKey.W))
                {
                    directionY = -playerSpeed;
                }
                else if (_keyboardService.IsKeyDown(KeyboardKey.S))
                {
                    directionY = playerSpeed;
                }

                // detect horizontal or x-axis direction
                if (_keyboardService.IsKeyDown(KeyboardKey.A))
                {
                    directionX = -playerSpeed;
                }
                else if (_keyboardService.IsKeyDown(KeyboardKey.D))
                {
                    directionX = playerSpeed;
                }

                // steer the player in the desired direction
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