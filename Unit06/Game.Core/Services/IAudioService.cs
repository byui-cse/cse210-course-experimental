using Byui.Game.Casting;


namespace Byui.Game.Services
{
    public interface IAudioService
    {
        void Initialize();
        void LoadMusic(string directory);
        void LoadSounds(string directory);
        void Pause(Music music);
        void Pause(Sound sound);
        void Play(Music music);
        void Play(Sound sound);
        void Resume(Music music);
        void Resume(Sound sound);
        void Stop(Music music);
        void Stop(Sound sound);
        void Release();
        void UnloadMusic();
        void UnloadSounds();
    }
}