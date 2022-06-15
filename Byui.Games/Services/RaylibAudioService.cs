using System.Collections.Generic;
using System.IO;
using Raylib_cs;


namespace Byui.Games.Services
{
    public class RaylibAudioService : IAudioService
    {
        private Dictionary<string, Music> _music = new Dictionary<string, Music>();
        private ISettingsService _settings = null;
        private Dictionary<string, Sound> _sounds = new Dictionary<string, Sound>();

        public RaylibAudioService(ISettingsService settings)
        {
            _settings = settings;
        }

        public void Initialize()
        {
            if (!Raylib.IsAudioDeviceReady())
            {
                Raylib.InitAudioDevice();
            }
        }

        public bool IsPlayingMusic(string posixFilepath)
        {
            Music music = GetRaylibMusic(posixFilepath);
            return Raylib.IsMusicStreamPlaying(music);
        }

        public bool IsPlayingSound(string posixFilepath)
        {
            Sound sound = GetRaylibSound(posixFilepath);
            return Raylib.IsSoundPlaying(sound);
        }
        
        public bool IsReady()
        {
            return Raylib.IsAudioDeviceReady();
        }

        public void PauseMusic(string posixFilepath)
        {
            Music music = GetRaylibMusic(posixFilepath);
            Raylib.PauseMusicStream(music);
        }

        public void PauseSound(string posixFilepath)
        {
            Sound sound = GetRaylibSound(posixFilepath);
            Raylib.PauseSound(sound);
        }

        public void PlayMusic(string posixFilepath)
        {
            Music music = GetRaylibMusic(posixFilepath);
            Raylib.PlayMusicStream(music);
        }

        public void PlaySound(string posixFilepath)
        {
            Sound sound = GetRaylibSound(posixFilepath);
            Raylib.PlaySound(sound);
        }

        public void Release()
        {
            if (Raylib.IsAudioDeviceReady())
            {
                UnloadMusic();
                UnloadSounds();
                Raylib.CloseAudioDevice();
            }
        }

        public void ResumeMusic(string posixFilepath)
        {
            Music music = GetRaylibMusic(posixFilepath);
            Raylib.ResumeMusicStream(music);
        }

        public void ResumeSound(string posixFilepath)
        {
            Sound sound = GetRaylibSound(posixFilepath);
            Raylib.ResumeSound(sound);
        }

        public void StopMusic(string posixFilepath)
        {
            Music music = GetRaylibMusic(posixFilepath);
            Raylib.StopMusicStream(music);
        }

        public void StopSound(string posixFilepath)
        {
            Sound sound = GetRaylibSound(posixFilepath);
            Raylib.StopSound(sound);
        }

        public void UpdateMusic(string posixFilepath)
        {
            Music music = GetRaylibMusic(posixFilepath);
            Raylib.UpdateMusicStream(music);
        }

        private Raylib_cs.Music GetRaylibMusic(string posixFilepath)
        {
            string filepath = posixFilepath.Replace('/', Path.DirectorySeparatorChar);
            if (!_music.ContainsKey(filepath))
            {
                _music[filepath] = Raylib.LoadMusicStream(filepath);
            }
            return _music[filepath];
        }

        private Raylib_cs.Sound GetRaylibSound(string posixFilepath)
        {
            string filepath = posixFilepath.Replace('/', Path.DirectorySeparatorChar);
            if (!_sounds.ContainsKey(filepath))
            {
                _sounds[filepath] = Raylib.LoadSound(filepath);
            }
            return _sounds[filepath];
        }

        private void UnloadMusic()
        {
            foreach (string filepath in _music.Keys)
            {
                Raylib_cs.Music music = _music[filepath];
                Raylib.UnloadMusicStream(music);
            }
        }

        private void UnloadSounds()
        {
            foreach (string filepath in _sounds.Keys)
            {
                Raylib_cs.Sound sound = _sounds[filepath];
                Raylib.UnloadSound(sound);
            }
        }

    }
}