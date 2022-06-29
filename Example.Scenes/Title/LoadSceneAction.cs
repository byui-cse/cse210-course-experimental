using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Example.Scenes.Game;
using Example.Scenes.Help;


namespace Example.Scenes.Title
{
    /// <summary>
    /// Loads the next scene when the corresponding key is pressed.
    /// </summary>
    public class LoadSceneAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;
        private SceneLoader _gameSceneLoader;
        private SceneLoader _helpSceneLoader;
        
        public LoadSceneAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
            _gameSceneLoader = new GameSceneLoader(serviceFactory);
            _helpSceneLoader = new HelpSceneLoader(serviceFactory);
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                if (_keyboardService.IsKeyPressed(KeyboardKey.S))
                {
                    _gameSceneLoader.Load(scene);
                }
                else if (_keyboardService.IsKeyDown(KeyboardKey.H))
                {
                    _helpSceneLoader.Load(scene);
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't load scene.", exception);
            }
        }
    }
}