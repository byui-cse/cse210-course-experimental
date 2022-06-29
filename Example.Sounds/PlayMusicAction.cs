using System;
using System.Runtime.Serialization.Formatters;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Sounds
{
    /// <summary>
    /// Plays background music for the example. Note the path to the music file comes from the
    /// program settings (see settings.json).
    /// </summary>
    public class PlayMusicAction : Byui.Games.Scripting.Action
    {
        private IAudioService _audioService;
        private ISettingsService _settingsService;

        public PlayMusicAction(IServiceFactory serviceFactory)
        {
            _audioService = serviceFactory.GetAudioService();
            _settingsService = serviceFactory.GetSettingsService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                string backgroundMusic = _settingsService.GetString("backgroundMusic");

                // start playing music if it isn't already
                if (!_audioService.IsPlayingMusic(backgroundMusic))
                {
                    _audioService.PlayMusic(backgroundMusic);
                }

                // update the audio buffer to keep playing it
                _audioService.UpdateMusic(backgroundMusic);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't play music.", exception);
            }
        }
    }
}