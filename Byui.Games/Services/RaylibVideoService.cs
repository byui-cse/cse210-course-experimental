using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Byui.Games.Casting;
using Raylib_cs;


namespace Byui.Games.Services
{
    public class RaylibVideoService : IVideoService
    {
        private const string DefaultCaption = "CSE210";
        private const int DefaultWidth = 480;
        private const int DefaultHeight = 640;
        
        private Raylib_cs.Color _background 
            = Raylib_cs.Color.BLACK;

        private Dictionary<string, Raylib_cs.Font> _fonts 
            = new Dictionary<string, Raylib_cs.Font>();

        private Settings _settings = null;
        
        private Dictionary<string, Texture2D> _textures 
            = new Dictionary<string, Texture2D>();
        
        public RaylibVideoService(Settings settings)
        {
            _settings = settings;
        }

        public void ClearBuffer()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(_background);
        }

        public void Draw(Animation animation)
        {
            string file = animation.GetFile();
            Texture2D texture = GetRaylibTexture(file);
            Vector2 position = animation.GetPosition();
            float rotation = animation.GetRotation();
            float scale = animation.GetScale();
            Raylib_cs.Color tint = GetRaylibColor(animation.GetTint());

            Raylib.DrawTextureEx(texture, position, rotation, scale, tint);
        }

        public void Draw(Circle circle)
        {
            int centerX = (int)circle.GetPosition().X;
            int centerY = (int)circle.GetPosition().Y;
            float radius = circle.GetRadius();
            Raylib_cs.Color color = GetRaylibColor(circle.GetColor());

            if (circle.IsFilled())
            {
                Raylib.DrawCircle(centerX, centerY, radius, color);
            }
            else
            {
                Raylib.DrawCircleLines(centerX, centerY, radius, color);
            }
        }

        public void Draw(Casting.Image image)
        {
            string file = image.GetFile();
            Texture2D texture = GetRaylibTexture(file);
            Vector2 position = image.GetPosition();
            float rotation = image.GetRotation();
            float scale = image.GetScale();
            Raylib_cs.Color tint = GetRaylibColor(image.GetTint());

            Raylib.DrawTextureEx(texture, position, rotation, scale, tint);
        }

        public void Draw(Label label)
        {
            string file = label.GetFont().GetFile();
            Raylib_cs.Font font = GetRaylibFont(file);
            string text = label.GetText();
            Vector2 position = label.GetPosition();
            float size = label.GetFont().GetSize();
            Raylib_cs.Color color = GetRaylibColor(label.GetFont().GetColor());

            int align = label.GetAlignment();
            float width = (int) Raylib.MeasureTextEx(font, text, size, 0).X;
            if (align == Label.RightAligned) position.X = position.X - width;
            if (align == Label.CenterAligned) position.X = position.X - (width / 2);

            Raylib.DrawTextEx(font, text, position, size, 0f, color);
        }

        public void Draw(Line line)
        {
            Vector2 start = line.GetStart();
            Vector2 end = line.GetEnd();
            Raylib_cs.Color color = GetRaylibColor(line.GetColor());

            Raylib.DrawLineV(start, end, color);
        }

        public void Draw(Polygon polygon)
        {
            Vector2 center = polygon.GetPosition();
            int sides = polygon.GetSides();
            float radius = polygon.GetRadius();
            float rotation = polygon.GetRotation();
            Raylib_cs.Color color = GetRaylibColor(polygon.GetColor());

            if (polygon.IsFilled())
            {
                Raylib.DrawPoly(center, sides, radius, rotation, color);
            }
            else
            {
                Raylib.DrawPolyLines(center, sides, radius, rotation, color);
            }
        }

        public void Draw(Casting.Rectangle rectangle)
        {
            int top = (int)rectangle.GetPosition().X;
            int left = (int)rectangle.GetPosition().Y;
            int width = (int)rectangle.GetSize().X;
            int height = (int)rectangle.GetSize().Y;
            Raylib_cs.Color color = GetRaylibColor(rectangle.GetColor());

            if (rectangle.IsFilled())
            {
                Raylib.DrawRectangle(top, left, width, height, color);
            }
            else
            {
                Raylib.DrawRectangleLines(top, left, width, height, color);
            }
        }

        public void FlushBuffer()
        {
            Raylib.EndDrawing(); 
        }

        public int GetFps()
        {
            return Raylib.GetFPS();
        }

        public float GetDeltaTime()
        {
            return Raylib.GetFrameTime();
        }

        public void Initialize()
        {
            if (!Raylib.IsWindowReady())
            {
                string caption = DefaultCaption;
                int width = DefaultWidth;
                int height = DefaultHeight;
                
                if (_settings.Has("screen", "caption")
                    && _settings.Has("screen", "width")
                    && _settings.Has("screen", "height"))
                {
                    caption = _settings.GetString("screen", "caption");
                    width = _settings.GetInt("screen", "width");
                    height = _settings.GetInt("screen", "height");
                }

                Raylib.InitWindow(width, height, caption);
                LoadFonts();
                LoadImages();
            }
        }

        public bool IsReady()
        {
            return Raylib.IsWindowReady();
        }

        public bool IsWindowOpen()
        {
            return !Raylib.WindowShouldClose();
        }

        public void Release()
        {
            if (!Raylib.WindowShouldClose())
            {
                UnloadFonts();
                UnloadImages();
                Raylib.CloseWindow();
            }
        }

        public void SetBackground(Casting.Color color)
        {
            _background = GetRaylibColor(color);
        }

        private List<string> GetFilepaths(string directory, string[] searchPatterns)
        {
            List<string> filepaths = new List<string>();
            foreach (string searchPpattern in searchPatterns)
            {
                string[] files = Directory.GetFiles(directory, searchPpattern);
                filepaths.AddRange(files);
            }
            return filepaths;
        }

        private Raylib_cs.Color GetRaylibColor(Casting.Color color)
        {
            Tuple<byte, byte, byte, byte> tuple = color.ToTuple();
            return new Raylib_cs.Color(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        }

        private Raylib_cs.Font GetRaylibFont(string file)
        {
            if (!_fonts.ContainsKey(file))
            {
                throw new ArgumentException($"{file} was not loaded.");
            }
            return _fonts[file];
        }

        private Raylib_cs.Texture2D GetRaylibTexture(string file)
        {
            if (!_textures.ContainsKey(file))
            {
                throw new ArgumentException($"{file} was not loaded.");
            }
            return _textures[file];
        }

        private void LoadFonts()
        {
            if (_settings.Has("fonts", "filetypes") 
                && _settings.Has("fonts","directory"))
            {
                string filetypes = _settings.GetString("fonts", "filetypes");
                string directory = _settings.GetString("fonts", "directory");
                string[] searchPatterns = filetypes.Split(",");
                List<string> paths = GetFilepaths(directory, searchPatterns);
                foreach (string path in paths)
                {
                    string file = Path.GetFileName(path);
                    _fonts[file] = Raylib.LoadFont(path);
                }
            }
        }

        private void LoadImages()
        {
            if (_settings.Has("images", "filetypes") 
                && _settings.Has("images","directory"))
            {
                string filetypes = _settings.GetString("images", "filetypes");
                string directory = _settings.GetString("images", "directory");
                string[] searchPatterns = filetypes.Split(",");
                List<string> paths = GetFilepaths(directory, searchPatterns);
                foreach (string path in paths)
                {
                    string file = Path.GetFileName(path);
                    _textures[file] = Raylib.LoadTexture(path);
                }
            }
        }

        private void UnloadFonts()
        {
            foreach (string key in _fonts.Keys)
            {
                Raylib_cs.Font font = _fonts[key];
                Raylib.UnloadFont(font);
            }
        }

        private void UnloadImages()
        {
            foreach (string key in _textures.Keys)
            {
                Raylib_cs.Texture2D texture = _textures[key];
                Raylib.UnloadTexture(texture);
            }
        }

    }
}