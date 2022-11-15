using System;
using System.Collections.Generic;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Breaker.Menu
{
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
                List<Image> images = scene.GetAllActors<Image>("images");
                List<Label> labels = scene.GetAllActors<Label>("labels");
                
                _videoService.ClearBuffer();
                _videoService.Draw(images);
                _videoService.Draw(labels);
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }
    }
}