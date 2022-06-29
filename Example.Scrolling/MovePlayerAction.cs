using System;
using System.Collections.Generic;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Scrolling
{
    /// <summary>
    /// Moves the player within the game world while scrolling the screen.
    /// </summary>
    public class MovePlayerAction : Byui.Games.Scripting.Action
    {
        public MovePlayerAction()
        {
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors, including the camera, from the cast
                Camera camera = scene.GetFirstActor<Camera>("camera");
                Actor world = camera.GetWorld();
                Actor player = scene.GetFirstActor("player");
                
                // move the player and clamp it to the boundaries of the world.
                player.Move();
                player.ClampTo(world);    
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move player.", exception);
            }
        }
    }
}