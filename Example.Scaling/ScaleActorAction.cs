using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Scaling
{
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
                Actor actor = scene.GetFirstActor("actors");
                if (_keyboardService.IsKeyDown(KeyboardKey.W))
                {
                    float percent = (actor.GetScale() < 3.0) ? 0.025f : 0;
                    actor.Scale(percent);
                }
                else if (_keyboardService.IsKeyDown(KeyboardKey.S))
                {
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