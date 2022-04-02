using System.Numerics;


namespace Byui.Games.Services
{
    public interface IMouseService
    {
        Vector2 GetCoordinates();
        bool IsButtonDown(MouseButton button);
        bool IsButtonPressed(MouseButton button);
        bool IsButtonReleased(MouseButton button);
        bool IsButtonUp(MouseButton button);
    }
}