using System;
using System.Runtime.Serialization.Formatters;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Sounds
{
    public class PlayMusicAction : Byui.Games.Scripting.Action
    {
        private string _musicFile = "Assets/spinning-monkeys.mp3";
        private IAudioService _audioService;

        public PlayMusicAction(IServiceFactory serviceFactory)
        {
            _audioService = serviceFactory.GetAudioService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                if (!_audioService.IsPlayingMusic(_musicFile))
                {
                    _audioService.PlayMusic(_musicFile);
                }
                _audioService.UpdateMusic(_musicFile);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't play music.", exception);
            }
        }
    }
}