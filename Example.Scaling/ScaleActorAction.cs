using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Scaling
{
    /// <summary>
    /// Scales the actor up or down depending on key presses.
    /// </summary>
    public class ScaleActorAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;

        public ScaleActorAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actor from the cast
                Actor actor = scene.GetFirstActor("actors");

                // scale the actor up or down 
                if (_keyboardService.IsKeyDown(KeyboardKey.W))
                {
                    // scale the actor up a maximum of 300 percent
                    float percent = (actor.GetScale() < 3.0) ? 0.025f : 0;
                    actor.Scale(percent);
                }
                else if (_keyboardService.IsKeyDown(KeyboardKey.S))
                {
                    // scale the actor down to a minimum of 30 percent
                    float percent = (actor.GetScale() > 0.3) ? -0.025f : 0;
                    actor.Scale(percent);
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't scale actor.", exception);
            }
        }
    }
}