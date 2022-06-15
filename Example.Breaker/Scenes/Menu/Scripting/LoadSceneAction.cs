using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Example.Breaker.Game;
using Example.Breaker.Shared;

namespace Example.Breaker.Menu
{
    public class LoadSceneAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;
        private SceneLoader _gameSceneLoader;
        
        public LoadSceneAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
            _gameSceneLoader = new GameSceneLoader(serviceFactory);
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                if (_keyboardService.IsKeyPressed(KeyboardKey.Enter))
                {
                    _gameSceneLoader.Load(scene);
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't load scene.", exception);
            }
        }
    }
}