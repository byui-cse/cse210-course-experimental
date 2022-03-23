using System;


namespace Byui.Game.Scripting
{
    /// <summary>
    /// A simulation clock.
    /// </summary>
    class Clock
    {
        private static DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        private double _available = 0D;
        private double _framerate = 0D;
        private double _previous = 0D;
        private bool _running = false;
        
        public Clock(int framesPerSecond)
        {
            _framerate = 1D / framesPerSecond;
            AddTime();
        }

        public void AddTime()
        {
            double current = GetTime();
            double elapsed = current - _previous;
            _available += elapsed;
            _previous = current;
        }

        /// <summary>
        /// Gets an alpha value which can be used by rendering classes to perform linear 
        /// interpolation or predict where Actors should appear.
        /// </summary>
        /// <returns>The alpha value</returns>
        public double GetAlpha()
        {
            return _available / _framerate;
        }

        public bool HasTime()
        {
            return _available >= _framerate;
        }

        public bool IsRunning()
        {
            return _running;
        }

        public void Start()
        {
            _running = true;
        }

        public void Stop()
        {
            _running = false;
        }

        public void UseTime()
        {
            _available -= _framerate;
        }

        private double GetTime()
        {
            DateTime now = DateTime.Now.ToUniversalTime();
            TimeSpan duration = DateTime.Now.ToUniversalTime() - Epoch;
            return duration.TotalSeconds;
        }
    }
}