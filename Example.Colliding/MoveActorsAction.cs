using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Colliding
{
    public class MoveActorsAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;

        public MoveActorsAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                Actor screen = scene.GetFirstActor("screen");
                Actor actor1 = scene.GetFirstActor("actor1");
                Actor actor2 = scene.GetFirstActor("actor2");
                
                actor1.Move();
                actor1.BounceIn(screen);

                actor2.Move();
                actor2.BounceIn(screen);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move actors.", exception);
            }
        }
    }
}