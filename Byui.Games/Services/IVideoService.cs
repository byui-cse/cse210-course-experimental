using Byui.Games.Casting;


namespace Byui.Games.Services
{
    public interface IVideoService
    {
        void ClearBuffer();
        void Draw(Animation animation);
        void Draw(Circle circle);
        void Draw(Image image);
        void Draw(Label label);
        void Draw(Line line);
        void Draw(Polygon polygon);
        void Draw(Rectangle rectangle);
        void FlushBuffer();
        int GetFps();
        float GetDeltaTime();
        void Initialize();
        bool IsReady();
        bool IsWindowOpen();
        void Release();
        void SetBackground(Color color);
    }
}