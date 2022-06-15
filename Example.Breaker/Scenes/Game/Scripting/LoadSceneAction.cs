using System;
using System.Diagnostics;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Example.Breaker.Over;
using Example.Breaker.Shared;


namespace Example.Breaker.Game
{
    public class LoadSceneAction : Byui.Games.Scripting.Action
    {
        private SceneLoader _overSceneLoader;

        public LoadSceneAction(IServiceFactory serviceFactory)
        {
            _overSceneLoader = new OverSceneLoader(serviceFactory);
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                Lives status = scene.GetFirstActor<Lives>("lives");
                if (status.IsDead())
                {
                    _overSceneLoader.Load(scene);
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't load scene.", exception);
            }
        }
    }
}