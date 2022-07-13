using System.Collections.Generic;
using Byui.Games.Casting;


namespace Byui.Games.Services
{
    public interface IVideoService
    {
        void ClearBuffer();
        void Draw(Actor actor);
        void Draw(Actor actor, Camera camera);
        void Draw(Image image);
        void Draw(Image image, Camera camera);
        void Draw(Label label);
        void Draw(Label label, Camera camera);
        void Draw(List<Actor> actors);
        void Draw(List<Actor> actors, Camera camera);
        void Draw(List<Image> images);
        void Draw(List<Image> images, Camera camera);
        void Draw(List<Label> labels);
        void Draw(List<Label> labels, Camera camera);
        void DrawGrid(int cellSize, Color color);
        void DrawGrid(int cellSize, Color color, Camera camera);
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