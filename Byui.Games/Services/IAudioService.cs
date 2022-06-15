namespace Byui.Games.Services
{
    public interface IAudioService
    {
        void Initialize();
        bool IsPlayingMusic(string filename);
        bool IsPlayingSound(string filename);
        bool IsReady();
        void PauseMusic(string filename);
        void PauseSound(string filename);
        void PlayMusic(string filename);
        void PlaySound(string filename);
        void ResumeMusic(string filename);
        void ResumeSound(string filename);
        void StopMusic(string filename);
        void StopSound(string filename);
        void UpdateMusic(string filename);
        void Release();
    }
}