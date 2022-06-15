using System;
using System.Collections.Generic;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Breaker.Game
{
    public class ApplyMultiballAction : Byui.Games.Scripting.Action
    {
        private int DEFAULT_EXTRA_BALLS = 3;

        private ISettingsService _settingsService;

        public ApplyMultiballAction(IServiceFactory serviceFactory) 
        {
            _settingsService = serviceFactory.GetSettingsService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                ActorFactory actorFactory = new ActorFactory(_settingsService);
                Ball first = scene.GetFirstActor<Ball>("balls");
                for (int i = 0; i < DEFAULT_EXTRA_BALLS; i++)
                {
                    Ball ball = actorFactory.CreateBall();
                    ball.MoveTo(first.GetPosition());
                    scene.AddActor("balls", ball);
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't apply multiball.", exception);
            }
        }
    }
}