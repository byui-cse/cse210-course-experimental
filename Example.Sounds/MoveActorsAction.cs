using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Sounds
{
    /// <summary>
    /// Moves the actor and bounces it off the screen walls. Note the path to the bounce sound file 
    /// comes from the program settings (see settings.json).
    /// </summary>
    public class MoveActorsAction : Byui.Games.Scripting.Action
    {
        private IAudioService _audioService;
        private ISettingsService _settingsService;

        public MoveActorsAction(IServiceFactory serviceFactory)
        {
            _audioService = serviceFactory.GetAudioService();
            _settingsService = serviceFactory.GetSettingsService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                string bounceSound = _settingsService.GetString("bounceSound");
                Actor screen = scene.GetFirstActor("screen");
                Actor actor = scene.GetFirstActor("actors");
                
                // move the main actor
                actor.Move();
                bool hasBounced = actor.BounceIn(screen);

                // play the bounce sound if it did
                if (hasBounced)
                {
                    _audioService.PlaySound(bounceSound);
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move actors.", exception);
            }
        }
    }
}