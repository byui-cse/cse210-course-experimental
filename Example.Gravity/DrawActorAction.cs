using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Gravity
{
    /// <summary>
    /// Draws the actors on the screen.
    /// </summary>
    public class DrawActorAction : Byui.Games.Scripting.Action
    {
        private IVideoService _videoService;

        public DrawActorAction(IServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors from the cast
                Label label = (Label) scene.GetFirstActor("labels");
                Actor actor = scene.GetFirstActor("actors");
                
                // draw the actors on the screen using the video service
                _videoService.ClearBuffer();
                _videoService.Draw(label);
                _videoService.Draw(actor);
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }
    }
}