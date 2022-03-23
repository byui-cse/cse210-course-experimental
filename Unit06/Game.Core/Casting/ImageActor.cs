using System;


namespace Byui.Game.Casting
{
    /// <summary>
    /// A visible participant in the game.
    /// </summary>
    public abstract class ImageActor : Actor
    {
        private int _frame = 0;
        private string[] _files = new string[] {};
        private int _index = 0;
        private int _speed = int.MaxValue;
        
        public ImageActor()
        {
        }

        public void Animate(string[] files, int speed)
        {
            _files = files;
            _speed = speed;
        }

        public void Display(string file)
        {
            _files = new string[] { file };
        }

        public string GetImage()
        {
            _frame++;
            if (_frame >= _speed)
            {
                _frame = 0;
                _index = (_index + 1) % _files.Length;
            }
            return _files[_index];
        }
    }
}