using System;
using System.Collections.Generic;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Breaker.Game
{
    public class ApplyExtraLifeAction : Byui.Games.Scripting.Action
    {
        public ApplyExtraLifeAction() { }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                Lives lives = scene.GetFirstActor<Lives>("lives");
                lives.AddLife();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't apply extra life.", exception);
            }
        }
    }
}