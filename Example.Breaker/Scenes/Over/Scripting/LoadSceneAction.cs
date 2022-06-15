using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Example.Breaker.Menu;
using Example.Breaker.Shared;

namespace Example.Breaker.Over
{
    public class LoadSceneAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;
        private SceneLoader _menuSceneLoader;
        
        public LoadSceneAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
            _menuSceneLoader = new MenuSceneLoader(serviceFactory);
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                if (_keyboardService.IsKeyPressed(KeyboardKey.Enter))
                {
                    _menuSceneLoader.Load(scene);
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't change scene.", exception);
            }
        }
    }
}