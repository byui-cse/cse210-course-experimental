using System.Numerics;


namespace Byui.Games.Casting
{
    /// <summary>
    /// A visible Actor.
    /// </summary>
    /// <remarks>
    /// The responsibility of Image is to define the image-based appearance of an Actor.
    /// </remarks>
    public class Image : Texture
    {
        private string _file = string.Empty;
        private float _rotation = 0f;
        private float _scale = 1f;

        public Image() { }

        public string GetFile()
        {
            return _file;
        }

        public float GetRotation()
        {
            return _rotation;
        }

        public float GetScale()
        {
            return _scale;
        }

        public virtual void SetFile(string file)
        {
            Validator.CheckNotBlank(file);
            _file = file;
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
    }
}