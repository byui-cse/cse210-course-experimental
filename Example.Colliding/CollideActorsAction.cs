using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Colliding
{
    public class CollideActorsAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;

        public CollideActorsAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                Actor actor1 = scene.GetFirstActor("actor1");
                Actor actor2 = scene.GetFirstActor("actor2");
                
                if (actor2.Overlaps(actor1))
                {
                    actor2.Tint(Color.Green());
                }
                else
                {
                    actor2.Tint(Color.Red());
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't check if actors collide.", exception);
            }
        }
    }
}