using System.Numerics;
using Byui.Games.Casting;

namespace Byui.Games.Services
{
    public class RaylibServiceFactory : IServiceFactory
    {
        private static IAudioService AudioService;
        private static IKeyboardService KeyboardService;
        private static IMouseService MouseService;
        private static IPhysicsService PhysicsService;
        private static IVideoService VideoService;

        public RaylibServiceFactory(Settings settings)
        {
            AudioService = new RaylibAudioService(settings);
            KeyboardService = new RaylibKeyboardService();
            MouseService = new RaylibMouseService();
            PhysicsService = new RaylibPhysicsService();
            VideoService = new RaylibVideoService(settings);
        }

        public IAudioService GetAudioService()
        {
            return AudioService;
        }

        public IKeyboardService GetKeyboardService()
        {
            return KeyboardService;
        }

        public IMouseService GetMouseService()
        {
            return MouseService;
        }

        public IPhysicsService GetPhysicsService()
        {
            return PhysicsService;
        }

        public IVideoService GetVideoService()
        {
            return VideoService;
        }
    }
}