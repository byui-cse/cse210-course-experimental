using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Settings
{
    public class DrawImageAction : Byui.Games.Scripting.Action
    {
        private IVideoService _videoService;

        public DrawImageAction(IServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // Get the actor we want to draw from the scene.
                Image robot = scene.GetFirstActor<Image>("robots");

                /*
                   Use the video service to draw the actor. Note that we have to clear and flush 
                   the buffer before and after drawing the actors. 
                   
                   In this case, we are using a simple Actor instance. Refer to the other example
                   projects to learn how to draw images, etc.
                */
                _videoService.ClearBuffer();
                _videoService.Draw(robot);
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw robot.", exception);
            }
        }
    }
}