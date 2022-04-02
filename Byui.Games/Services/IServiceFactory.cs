namespace Byui.Games.Services
{
    public interface IServiceFactory
    {
        IAudioService GetAudioService();
        IKeyboardService GetKeyboardService();
        IMouseService GetMouseService();
        IPhysicsService GetPhysicsService();
        IVideoService GetVideoService();
    }
}