using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Scaling
{
    /// <summary>
    /// Moves the actors and wraps them around the screen boundaries. Note, this is different from
    /// steering them which only changes their direction. The call to actor.Move() is what updates
    /// their position on the screen.
    /// </summary>
    public class MoveActorAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;

        public MoveActorAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors from the scene
                Actor actor = scene.GetFirstActor("actors");
                Actor screen = scene.GetFirstActor("screen");
                
                // move the actor and wrap it around the screen boundaries
                actor.Move();
                actor.WrapIn(screen);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move actor.", exception);
            }
        }
    }
}