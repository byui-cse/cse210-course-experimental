using System;
using System.Collections.Generic;
using System.IO;
using Byui.Games.Casting;
using Byui.Games.Services;
using Raylib_cs;


namespace Byui.Games.Services
{
    public class RaylibAudioService : IAudioService
    {
        private Dictionary<string, Raylib_cs.Music> _music 
            = new Dictionary<string, Raylib_cs.Music>();
        
        private Settings _settings = null;
        
        private Dictionary<string, Raylib_cs.Sound> _sounds
            = new Dictionary<string, Raylib_cs.Sound>();

        public RaylibAudioService(Settings settings)
        {
            _settings = settings;
        }

        public void Initialize()
        {
            if (!Raylib.IsAudioDeviceReady())
            {
                Raylib.InitAudioDevice();
                LoadMusic();
                LoadSounds();
            }
        }

        public bool IsPlayingMusic(string filename)
        {
            Music music = GetRaylibMusic(filename);
            return Raylib.IsMusicStreamPlaying(music);
        }

        public bool IsPlayingSound(string filename)
        {
            Sound sound = GetRaylibSound(filename);
            return Raylib.IsSoundPlaying(sound);
        }
        
        public bool IsReady()
        {
            return Raylib.IsAudioDeviceReady();
        }

        public void PauseMusic(string filename)
        {
            Music music = GetRaylibMusic(filename);
            Raylib.PauseMusicStream(music);
        }

        public void PauseSound(string filename)
        {
            Sound sound = GetRaylibSound(filename);
            Raylib.PauseSound(sound);
        }

        public void PlayMusic(string filename)
        {
            Music music = GetRaylibMusic(filename);
            Raylib.PlayMusicStream(music);
        }

        public void PlaySound(string filename)
        {
            Sound sound = GetRaylibSound(filename);
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

        public void ResumeMusic(string filename)
        {
            Music music = GetRaylibMusic(filename);
            Raylib.ResumeMusicStream(music);
        }

        public void ResumeSound(string filename)
        {
            Sound sound = GetRaylibSound(filename);
            Raylib.ResumeSound(sound);
        }

        public void StopMusic(string filename)
        {
            Music music = GetRaylibMusic(filename);
            Raylib.StopMusicStream(music);
        }

        public void StopSound(string filename)
        {
            Sound sound = GetRaylibSound(filename);
            Raylib.StopSound(sound);
        }

        private List<string> GetFilepaths(string directory, string[] searchPatterns)
        {
            List<string> filepaths = new List<string>();
            foreach (string searchPpattern in searchPatterns)
            {
                string[] files = Directory.GetFiles(directory, searchPpattern);
                filepaths.AddRange(files);
            }
            return filepaths;
        }

        private Raylib_cs.Music GetRaylibMusic(string filename)
        {
            if (!_music.ContainsKey(filename))
            {
                throw new ArgumentException($"{filename} was not loaded.");
            }
            return _music[filename];
        }

        private Raylib_cs.Sound GetRaylibSound(string filename)
        {
            if (!_sounds.ContainsKey(filename))
            {
                throw new ArgumentException($"{filename} was not loaded.");
            }
            return _sounds[filename];
        }

        private void LoadMusic()
        {
            if (_settings.Has("music", "filetypes")
                && _settings.Has("music", "directory"))
            {
                string filetypes = _settings.GetString("music", "filetypes");
                string directory = _settings.GetString("music", "directory");
                string[] searchPatterns = filetypes.Split(",");
                List<string> filepaths = GetFilepaths(directory, searchPatterns);
                foreach (string filepath in filepaths)
                {
                    string filename = Path.GetFileName(filepath);
                    _music[filename] = Raylib.LoadMusicStream(filepath);
                }
            }
        }

        private void LoadSounds()
        {
            if (_settings.Has("sounds", "filetypes")
                && _settings.Has("sounds", "directory"))
            {
                string filetypes = _settings.GetString("sounds", "filetypes");
                string directory = _settings.GetString("sounds", "directory");
                string[] searchPatterns = filetypes.Split(",");
                List<string> filepaths = GetFilepaths(directory, searchPatterns);
                foreach (string filepath in filepaths)
                {
                    string filename = Path.GetFileName(filepath);
                    _sounds[filename] = Raylib.LoadSound(filepath);
                }
            }
        }

        private void UnloadMusic()
        {
            foreach (string file in _music.Keys)
            {
                Raylib_cs.Music music = _music[file];
                Raylib.UnloadMusicStream(music);
            }
        }

        private void UnloadSounds()
        {
            foreach (string file in _sounds.Keys)
            {
                Raylib_cs.Sound sound = _sounds[file];
                Raylib.UnloadSound(sound);
            }
        }

    }
}