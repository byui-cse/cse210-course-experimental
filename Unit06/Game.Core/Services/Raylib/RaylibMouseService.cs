using System.Collections.Generic;
using Byui.Game.Casting;
using Raylib_cs;


namespace Byui.Game.Services
{
    /// <summary>
    /// A Raylib implementation of IMouseService.
    /// </summary>
    public class RaylibMouseService : IMouseService
    {
        private Dictionary<MouseButton, Raylib_cs.MouseButton> _buttons
                = new Dictionary<MouseButton, Raylib_cs.MouseButton>() {

            { MouseButton.Left, Raylib_cs.MouseButton.MOUSE_BUTTON_LEFT },
            { MouseButton.Middle, Raylib_cs.MouseButton.MOUSE_BUTTON_MIDDLE },
            { MouseButton.Right, Raylib_cs.MouseButton.MOUSE_BUTTON_RIGHT },
            { MouseButton.Side, Raylib_cs.MouseButton.MOUSE_BUTTON_SIDE }

        };

        public RaylibMouseService()
        {
        }

        public Point GetCoordinates()
        {
            int x = Raylib.GetMouseX();
            int y = Raylib.GetMouseY();
            return new Point(x, y);
        }

        public bool IsButtonDown(MouseButton button)
        {
            Raylib_cs.MouseButton raylibButton = _buttons[button];
            return Raylib.IsMouseButtonDown(raylibButton);
        }

        public bool IsButtonPressed(MouseButton button)
        {
            Raylib_cs.MouseButton raylibButton = _buttons[button];
            return Raylib.IsMouseButtonPressed(raylibButton);
        }

        public bool IsButtonReleased(MouseButton button)
        {
            Raylib_cs.MouseButton raylibButton = _buttons[button];
            return Raylib.IsMouseButtonReleased(raylibButton);
        }

        public bool IsButtonUp(MouseButton button)
        {
            Raylib_cs.MouseButton raylibButton = _buttons[button];
            return Raylib.IsMouseButtonUp(raylibButton);
        }
    }
}