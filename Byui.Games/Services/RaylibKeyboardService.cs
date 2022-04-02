using System.Collections.Generic;
using Byui.Games.Casting;
using Raylib_cs;


namespace Byui.Games.Services
{
    /// <summary>
    /// A Raylib implementation of IKeyboardService.
    /// </summary>
    public class RaylibKeyboardService : IKeyboardService
    {
        private Dictionary<KeyboardKey, Raylib_cs.KeyboardKey> _keys
            = new Dictionary<KeyboardKey, Raylib_cs.KeyboardKey>() 
        {
            { KeyboardKey.A, Raylib_cs.KeyboardKey.KEY_A },
            { KeyboardKey.B, Raylib_cs.KeyboardKey.KEY_B },
            { KeyboardKey.C, Raylib_cs.KeyboardKey.KEY_C },
            { KeyboardKey.D, Raylib_cs.KeyboardKey.KEY_D },
            { KeyboardKey.E, Raylib_cs.KeyboardKey.KEY_E },
            { KeyboardKey.F, Raylib_cs.KeyboardKey.KEY_F },
            { KeyboardKey.G, Raylib_cs.KeyboardKey.KEY_G },
            { KeyboardKey.H, Raylib_cs.KeyboardKey.KEY_H },
            { KeyboardKey.I, Raylib_cs.KeyboardKey.KEY_I },
            { KeyboardKey.J, Raylib_cs.KeyboardKey.KEY_J },
            { KeyboardKey.K, Raylib_cs.KeyboardKey.KEY_K },
            { KeyboardKey.L, Raylib_cs.KeyboardKey.KEY_L },
            { KeyboardKey.M, Raylib_cs.KeyboardKey.KEY_M },
            { KeyboardKey.N, Raylib_cs.KeyboardKey.KEY_N },
            { KeyboardKey.O, Raylib_cs.KeyboardKey.KEY_O },
            { KeyboardKey.P, Raylib_cs.KeyboardKey.KEY_P },
            { KeyboardKey.Q, Raylib_cs.KeyboardKey.KEY_Q },
            { KeyboardKey.R, Raylib_cs.KeyboardKey.KEY_R },
            { KeyboardKey.S, Raylib_cs.KeyboardKey.KEY_S },
            { KeyboardKey.T, Raylib_cs.KeyboardKey.KEY_T },
            { KeyboardKey.U, Raylib_cs.KeyboardKey.KEY_U },
            { KeyboardKey.V, Raylib_cs.KeyboardKey.KEY_V },
            { KeyboardKey.W, Raylib_cs.KeyboardKey.KEY_W },
            { KeyboardKey.X, Raylib_cs.KeyboardKey.KEY_X },
            { KeyboardKey.Y, Raylib_cs.KeyboardKey.KEY_Y },
            { KeyboardKey.Z, Raylib_cs.KeyboardKey.KEY_Z },
            { KeyboardKey.One, Raylib_cs.KeyboardKey.KEY_ONE },
            { KeyboardKey.Two, Raylib_cs.KeyboardKey.KEY_TWO },
            { KeyboardKey.Three, Raylib_cs.KeyboardKey.KEY_THREE },
            { KeyboardKey.Four, Raylib_cs.KeyboardKey.KEY_FOUR },
            { KeyboardKey.Five, Raylib_cs.KeyboardKey.KEY_FIVE },
            { KeyboardKey.Six, Raylib_cs.KeyboardKey.KEY_SIX },
            { KeyboardKey.Seven, Raylib_cs.KeyboardKey.KEY_SEVEN },
            { KeyboardKey.Eight, Raylib_cs.KeyboardKey.KEY_EIGHT },
            { KeyboardKey.Nine, Raylib_cs.KeyboardKey.KEY_NINE },
            { KeyboardKey.Zero, Raylib_cs.KeyboardKey.KEY_ZERO },
            { KeyboardKey.Left, Raylib_cs.KeyboardKey.KEY_LEFT },
            { KeyboardKey.Right, Raylib_cs.KeyboardKey.KEY_RIGHT },
            { KeyboardKey.Up, Raylib_cs.KeyboardKey.KEY_UP },
            { KeyboardKey.Down, Raylib_cs.KeyboardKey.KEY_DOWN },
            { KeyboardKey.Enter, Raylib_cs.KeyboardKey.KEY_ENTER },
            { KeyboardKey.Escape, Raylib_cs.KeyboardKey.KEY_ESCAPE },
            { KeyboardKey.Space, Raylib_cs.KeyboardKey.KEY_SPACE }
        };

        public RaylibKeyboardService()
        {
        }

        public bool IsKeyDown(KeyboardKey key)
        {
            Raylib_cs.KeyboardKey raylibKey = _keys[key];
            return Raylib.IsKeyDown(raylibKey);
        }

        public bool IsKeyPressed(KeyboardKey key)
        {
            Raylib_cs.KeyboardKey raylibKey = _keys[key];
            return Raylib.IsKeyPressed(raylibKey);
        }

        public bool IsKeyReleased(KeyboardKey key)
        {
            Raylib_cs.KeyboardKey raylibKey = _keys[key];
            return Raylib.IsKeyReleased(raylibKey);
        }

        public bool IsKeyUp(KeyboardKey key)
        {
            Raylib_cs.KeyboardKey raylibKey = _keys[key];
            return Raylib.IsKeyUp(raylibKey);
        }
    }
}