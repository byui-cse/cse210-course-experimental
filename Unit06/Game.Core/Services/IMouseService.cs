using Byui.Game.Casting;


namespace Byui.Game.Services
{
    public interface IMouseService
    {
        Point GetCoordinates();
        bool IsButtonDown(MouseButton button);
        bool IsButtonPressed(MouseButton button);
        bool IsButtonReleased(MouseButton button);
        bool IsButtonUp(MouseButton button);
    }
}