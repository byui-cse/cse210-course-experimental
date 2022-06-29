using System;
using System.Numerics;


namespace Byui.Games.Casting
{
    /// <summary>
    /// A visible Actor.
    /// </summary>
    /// <remarks>
    /// The responsibility of Image is to define the image-based appearance of an Actor.
    /// </remarks>
    public class Camera : Actor
    {
        private Actor _focus;
        private Actor _screen;
        private Actor _world;
        
        public Camera(Actor focus, Actor screen, Actor world) 
        {
            _focus = focus;
            _screen = screen;
            _world = world;
        }

        public override Vector2 GetPosition()
        {
            Vector2 minOffset = new Vector2(0, 0);
            Vector2 maxOffset = _world.GetSize() - _screen.GetSize();
            Vector2 position = _focus.GetCenter() - _screen.GetCenter();
            float x = Math.Clamp(position.X, minOffset.X, maxOffset.X);
            float y = Math.Clamp(position.Y, minOffset.Y, maxOffset.Y);
            return new Vector2(x, y);
        }

        public Actor GetFocus()
        {
            return _focus;
        }

        public Actor GetScreen()
        {
            return _screen;
        }

        public Actor GetWorld()
        {
            return _world;
        }
    }
}