using System;
using System.Collections.Generic;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Images
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
                List<Image> robots = scene.GetAllActors<Image>("robots");
                _videoService.ClearBuffer();
                foreach (Image robot in robots)
                {
                    _videoService.Draw(robot);
                }
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw robots.", exception);
            }
        }
    }
}