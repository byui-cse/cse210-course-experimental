using System;


namespace Byui.Games.Casting
{
    /// <summary>
    /// An Animatable Actor.
    /// </summary>
    public class Animation : Texture
    {
        private string[] _files = new string[] { };
        private bool _repeated = false;
        private float _rotation = 0f;
        private float _scale = 1f;
        private bool _started = false;

        private int _frame = 0;
        private int _fps = 60;
        private int _frames = 0;
        private int _index = 0;
        private int _speed = 0;
        
        public Animation() { }

        public string GetFile()
        {
            if (_started)
            {
                Advance();
            }
            return _files[_index];
        }

        public float GetRotation()
        {
            return _rotation;
        }

        public float GetScale()
        {
            return _scale;
        }

        public virtual void SetFiles(string[] files)
        {
            Validator.CheckNotEmpty(files);
            _files = files;
        }

        public virtual void SetFps(int fps)
        {
            Validator.CheckGreaterThan(fps, 0);
            _fps = fps;
        }

        public virtual void SetFrames(int frames)
        {
            Validator.CheckGreaterThan(frames, 0);
            _frames = frames;
        }

        public void SetRotation(float degrees)
        {
            _rotation = degrees;
        }

        public void SetScale(float percent)
        {
            Validator.CheckGreaterThan(percent, 0);
            _scale = percent;
        }

        public void SetSpeed(int speed)
        {
            Validator.CheckGreaterThan(speed, 0);
            _speed = speed;
        }

        public void Start()
        {
            _started = true;
        }

        public void Stop()
        {
            _started = false;
        }

        private void Advance()
        {
            _frame++;
            if (_frame >= (_fps / _speed))
            {
                if (_repeated)
                {
                    _index = (_index + 1) % _frames;
                }
                else
                {
                    _index = Math.Min(_index + 1, _frames - 1);
                }
            }
        }
    }
}