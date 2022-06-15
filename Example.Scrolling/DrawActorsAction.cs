using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Scrolling
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
                _videoService.ClearBuffer();
                DrawGrid(scene);
                DrawPlayer(scene);
                DrawInstructions(scene);
                DrawStatus(scene);
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }

        private void DrawGrid(Scene scene)
        {
            Camera camera = scene.GetFirstActor<Camera>("camera");
            _videoService.DrawGrid(160, Color.Gray(), camera);
        }

        private void DrawInstructions(Scene scene)
        {
            Label instructions = scene.GetFirstActor<Label>("instructions");
            _videoService.Draw(instructions);
        }

        private void DrawPlayer(Scene scene)
        {
            Camera camera = scene.GetFirstActor<Camera>("camera");
            Actor player = scene.GetFirstActor("player");
            _videoService.Draw(player, camera);
        }

        private void DrawStatus(Scene scene)
        {
            Label status = scene.GetFirstActor<Label>("status");
            _videoService.Draw(status);
        }

    }
}