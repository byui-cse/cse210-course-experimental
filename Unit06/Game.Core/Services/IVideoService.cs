using Byui.Game.Casting;


namespace Byui.Game.Services
{
    public interface IVideoService
    {
        void ClearBuffer();
        void Draw(ImageActor actor, double alpha);
        void Draw(LabelActor actor, double alpha);
        void FlushBuffer();
        void Initialize();
        bool IsWindowOpen();
        void LoadFonts(string directory);
        void LoadImages(string directory);
        void Release();
        void UnloadFonts();
        void UnloadImages();
    }
}