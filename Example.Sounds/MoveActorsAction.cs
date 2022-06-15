using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Sounds
{
    public class MoveActorsAction : Byui.Games.Scripting.Action
    {
        private IAudioService _audioService;

        public MoveActorsAction(IServiceFactory serviceFactory)
        {
            _audioService = serviceFactory.GetAudioService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                Actor screen = scene.GetFirstActor("screen");
                Actor actor = scene.GetFirstActor("actors");
                
                actor.Move();
                bool bounced = actor.BounceIn(screen);

                if (bounced)
                {
                    _audioService.PlaySound("Assets/bounce.wav");
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move actors.", exception);
            }
        }
    }
}