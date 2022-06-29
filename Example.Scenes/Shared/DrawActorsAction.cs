using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Scenes.Shared
{
    /// <summary>
    /// A draw actors action that can be used by all the scenes in the game.
    /// </summary>
    public class DrawActorsAction : Byui.Games.Scripting.Action
    {
        private IVideoService _videoService;

        public DrawActorsAction(IServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors from the scene
                Label title = scene.GetFirstActor<Label>("title");
                Label instructions = scene.GetFirstActor<Label>("instructions");

                // draw the actors on the screen
                _videoService.ClearBuffer();
                _videoService.Draw(title);
                _videoService.Draw(instructions);
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }
    }
}