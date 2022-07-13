using System;
using System.Numerics;


namespace Byui.Games.Casting
{
    /// <summary>
    /// A participant in the game.
    /// </summary>
    public class Actor
    {
        private bool _enabled = true;
        private Vector2 _position = Vector2.Zero;
        private float _rotation = 0f;
        private float _scale = 1f;
        private Vector2 _size = Vector2.Zero;
        private Color _tint = Color.White();
        private Vector2 _velocity = Vector2.Zero;
        
        public Actor() { }

        public virtual bool BounceIn(Actor region)
        {
            Validator.CheckNotNull(region);
            bool bounced = false;

            if (_enabled)
            {
                if (GetLeft() <= region.GetLeft() || GetRight() >= region.GetRight())
                {
                    Vector2 oldVelocity = GetVelocity();
                    Vector2 newVelocity = new Vector2(oldVelocity.X * -1, oldVelocity.Y);
                    Steer(newVelocity);
                    bounced = true;
                }
                else if (GetTop() <= region.GetTop() || GetBottom() >= region.GetBottom())
                {
                    Vector2 oldVelocity = GetVelocity();
                    Vector2 newVelocity = new Vector2(oldVelocity.X, oldVelocity.Y * -1);
                    Steer(newVelocity);
                    bounced = true;
                }
            }

            return bounced;
        }

        public virtual void ClampTo(Actor region)
        {
            Validator.CheckNotNull(region);
            
            if (_enabled)
            {
                float x = GetLeft();
                float y = GetTop();

                float maxX = region.GetRight() - GetWidth();
                float maxY = region.GetBottom() - GetHeight();
                float minX = region.GetLeft();
                float minY = region.GetTop();

                x = Math.Clamp(x, minX, maxX);
                y = Math.Clamp(y, minY, maxY);

                Vector2 newPosition = new Vector2(x, y);
                MoveTo(newPosition);
            }
        }

        public virtual void Enable()
        {
            _enabled = true;
        }

        public virtual void Disable()
        {
            _enabled = false;
        }

        public virtual float GetBottom()
        {
            return _position.Y + _size.Y;
        }

        public virtual Vector2 GetCenter()
        {
            float x = _position.X + (_size.X / 2);
            float y = _position.Y + (_size.Y / 2);
            return new Vector2(x, y);
        }

        public virtual float GetCenterX()
        {
            return _position.X + (_size.X / 2);
        }

        public virtual float GetCenterY()
        {
            return _position.Y + (_size.Y / 2);
        }

        public virtual float GetHeight()
        {
            return _size.Y;
        }

        public virtual float GetLeft()
        {
            return _position.X;
        }

        public virtual Vector2 GetPosition()
        {
            return _position;
        }

        public virtual Vector2 GetOriginalSize()
        {
            return _size;
        }

        public virtual float GetRight()
        {
            return _position.X + _size.X;
        }

        public virtual float GetRotation()
        {
            return _rotation;
        }

        public virtual float GetScale()
        {
            return _scale;
        }

        public virtual Vector2 GetSize()
        {
            return _size * _scale;
        }

        public virtual Color GetTint()
        {
            return _tint;
        }

        public virtual float GetTop()
        {
            return _position.Y;
        }

        public virtual Vector2 GetVelocity()
        {
            return _velocity;
        }

        public virtual float GetWidth()
        {
            return _size.X;
        }

        public virtual void Move()
        {
            if (_enabled)
            {
                _position = _position + _velocity;
            }
        }

        public virtual void Move(float gravity)
        {
            if (_enabled)
            {
                Vector2 force = new Vector2(_velocity.X, _velocity.Y + gravity);
                _position = _position + force;
            }
        }

        public virtual void MoveTo(Vector2 position)
        {
            _position = position;
        }

        public virtual void MoveTo(float x, float y)
        {
            _position = new Vector2(x, y);
        }

        public virtual bool Overlaps(Actor other)
        {
            return (this.GetLeft() < other.GetRight() && this.GetRight() > other.GetLeft()
                && this.GetTop() < other.GetBottom() && this.GetBottom() > other.GetTop());
        }

        public virtual bool Overlaps(Vector2 point)
        {
            return (this.GetLeft() <= point.X && this.GetRight() >= point.X
                && this.GetTop() <= point.Y && this.GetBottom() >= point.Y);
        }

        public virtual void Rotate(float degrees)
        {
            _rotation += degrees;
        }

        public virtual void RotateTo(float degrees)
        {
            _rotation = degrees;
        }

        public virtual void Scale(float percent)
        {
            _scale += percent;
        }

        public virtual void ScaleTo(float percent)
        {
            _scale = percent;
        }

        public virtual void Tint(Color color)
        {
            Validator.CheckNotNull(color);
            _tint = color;
        }

        public virtual void SizeTo(Vector2 size) 
        {
            _size = size;
        }

        public virtual void SizeTo(float width, float height) 
        {
            _size = new Vector2(width, height);
        }

        public virtual void Steer(Vector2 vector)
        {
            _velocity = vector;
        }

        public virtual void Steer(float vx, float vy)
        {
            _velocity = new Vector2(vx, vy);
        }

        public virtual void WrapIn(Actor region)
        {
            Validator.CheckNotNull(region);

            if (_enabled)
            {
                float x = this.GetLeft();
                float y = this.GetTop();

                float maxX = region.GetRight();
                float maxY = region.GetBottom();
                float minX = region.GetLeft() - this.GetWidth();
                float minY = region.GetTop() - this.GetHeight();

                if (x < minX) x = maxX;
                if (x > maxX) x = minX;
                if (y < minY) y = maxY;
                if (y > maxY) y = minY;

                Vector2 newPosition = new Vector2(x, y);
                MoveTo(newPosition);
            }
        }
    }
}