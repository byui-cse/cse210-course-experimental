using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Example.Scenes;
using Example.Scenes.Title;



namespace Example.Scenes.Over
{
    /// <summary>
    /// Loads the next scene when the corresponding key is pressed.
    /// </summary>
    public class LoadSceneAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;
        private SceneLoader _titleSceneLoader;
        
        public LoadSceneAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
            _titleSceneLoader = new TitleSceneLoader(serviceFactory);
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                if (_keyboardService.IsKeyPressed(KeyboardKey.Enter))
                {
                    _titleSceneLoader.Load(scene);
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't load scene.", exception);
            }
        }
    }
}