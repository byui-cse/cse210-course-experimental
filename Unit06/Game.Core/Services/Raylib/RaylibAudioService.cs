using System;
using System.Collections.Generic;
using System.IO;
using Byui.Game.Casting;
using Raylib_cs;


namespace Byui.Game.Services
{
    public class RaylibAudioService : IAudioService
    {
        private static readonly string[] AudioPatterns 
            = new string[] { "*.wav", "*.mp3", "*.acc", "*.wma" };

        private Dictionary<string, Raylib_cs.Music> _music 
            = new Dictionary<string, Raylib_cs.Music>();

        private Dictionary<string, Raylib_cs.Sound> _sounds 
            = new Dictionary<string, Raylib_cs.Sound>();

        public RaylibAudioService()
        {
        }

        public void Initialize()
        {
            if (!Raylib.IsAudioDeviceReady())
            {
                Raylib.InitAudioDevice();
            }
        }

        public void LoadMusic(string directory)
        {
            List<string> filepaths = FileUtil.GetFilepaths(directory, AudioPatterns);
            foreach (string filepath in filepaths)
            {
                string filename = Path.GetFileName(filepath);
                _music[filename] = Raylib.LoadMusicStream(filepath);
            }
        }

        public void LoadSounds(string directory)
        {
            List<string> filepaths = FileUtil.GetFilepaths(directory, AudioPatterns);
            foreach (string filepath in filepaths)
            {
                string filename = Path.GetFileName(filepath);
                _sounds[filename] = Raylib.LoadSound(filepath);
            }
        }

        public void Pause(Casting.Music music)
        {
            string file = music.GetFile();
            if (!_music.ContainsKey(file))
            {
                throw new ArgumentException($"{file} was not loaded.");
            }
            Raylib_cs.Music raylibMusic = _music[file];
            Raylib.PauseMusicStream(raylibMusic);
        }

        public void Pause(Casting.Sound sound)
        {
            string file = sound.GetFile();
            if (!_sounds.ContainsKey(file))
            {
                throw new ArgumentException($"{file} was not loaded.");
            }
            Raylib_cs.Sound raylibSound = _sounds[file];
            Raylib.PauseSound(raylibSound);
        }

        public void Play(Casting.Music music)
        {
            string file = music.GetFile();
            if (!_music.ContainsKey(file))
            {
                throw new ArgumentException($"{file} was not loaded.");
            }
            Raylib_cs.Music raylibMusic = _music[file];
            Raylib.PlayMusicStream(raylibMusic);
        }

        public void Play(Casting.Sound sound)
        {
            string file = sound.GetFile();
            if (!_sounds.ContainsKey(file))
            {
                throw new ArgumentException($"{file} was not loaded.");
            }
            Raylib_cs.Sound raylibSound = _sounds[file];
            Raylib.PlaySound(raylibSound);
        }

        public void Resume(Casting.Music music)
        {
            string file = music.GetFile();
            if (!_music.ContainsKey(file))
            {
                throw new ArgumentException($"{file} was not loaded.");
            }
            Raylib_cs.Music raylibMusic = _music[file];
            Raylib.ResumeMusicStream(raylibMusic);
        }

        public void Resume(Casting.Sound sound)
        {
            string file = sound.GetFile();
            if (!_sounds.ContainsKey(file))
            {
                throw new ArgumentException($"{file} was not loaded.");
            }
            Raylib_cs.Sound raylibSound = _sounds[file];
            Raylib.ResumeSound(raylibSound);
        }

        public void Stop(Casting.Music music)
        {
            string file = music.GetFile();
            if (!_music.ContainsKey(file))
            {
                throw new ArgumentException($"{file} was not loaded.");
            }
            Raylib_cs.Music raylibMusic = _music[file];
            Raylib.StopMusicStream(raylibMusic);
        }

        public void Stop(Casting.Sound sound)
        {
            string file = sound.GetFile();
            if (!_sounds.ContainsKey(file))
            {
                throw new ArgumentException($"{file} was not loaded.");
            }
            Raylib_cs.Sound raylibSound = _sounds[file];
            Raylib.StopSound(raylibSound);
        }

        public void Release()
        {
            if (Raylib.IsAudioDeviceReady())
            {
                Raylib.CloseAudioDevice();
            }
        }

        public void UnloadMusic()
        {
            foreach (string file in _music.Keys)
            {
                Raylib_cs.Music raylibMusic = _music[file];
                Raylib.UnloadMusicStream(raylibMusic);
            }
        }

        public void UnloadSounds()
        {
            foreach (string file in _sounds.Keys)
            {
                Raylib_cs.Sound raylibSound = _sounds[file];
                Raylib.UnloadSound(raylibSound);
            }
        }

    }
}