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
        private Raylib_cs.Color _background = Raylib_cs.Color.BLACK;
        private Dictionary<string, Font> _fonts = new Dictionary<string, Font>();
        private ISettingsService _settings = null;
        private Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();

        public RaylibVideoService(ISettingsService settings)
        {
            _settings = settings;
        }

        public void ClearBuffer()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(_background);
        }

        public void Draw(Actor actor)
        {
            Raylib_cs.Color color = GetRaylibColor(actor.GetTint());
            Vector2 position = actor.GetCenter();
            Vector2 size = actor.GetSize();
            float rotation = actor.GetRotation();
            
            Rectangle destination = new Rectangle(position.X, position.Y, size.X, size.Y);
            Vector2 origin = new Vector2(size.X / 2, size.Y / 2);
            
            Raylib.DrawRectanglePro(destination, origin, rotation, color);
        }

        public void Draw(Actor actor, Camera camera)
        {
            Actor focus = camera.GetFocus();
            Actor screen = camera.GetScreen();

            if (actor == focus || actor.Overlaps(screen))
            {
                Raylib_cs.Color color = GetRaylibColor(actor.GetTint());
                Vector2 position = actor.GetCenter() - camera.GetPosition();
                Vector2 size = actor.GetSize();
                float rotation = actor.GetRotation();

                Rectangle destination = new Rectangle(position.X, position.Y, size.X, size.Y);
                Vector2 origin = new Vector2(size.X / 2, size.Y / 2);

                Raylib.DrawRectanglePro(destination, origin, rotation, color);
            }
        }

        public void Draw(Casting.Image image)
        {
            Vector2 position = image.GetCenter();
            Vector2 originalSize = image.GetOriginalSize();
            Vector2 size = image.GetSize();
            
            Texture2D texture = GetRaylibTexture(image.GetFile());
            Rectangle source = new Rectangle(0, 0, originalSize.X, originalSize.Y);
            Rectangle destination = new Rectangle(position.X, position.Y, size.X, size.Y);
            Vector2 origin = new Vector2(size.X / 2, size.Y / 2);
            float rotation = image.GetRotation();
            Raylib_cs.Color tint = GetRaylibColor(image.GetTint());
            
            Raylib.DrawTexturePro(texture, source, destination, origin, rotation, tint);
        }

        public void Draw(Casting.Image image, Camera camera)
        {
            Actor focus = camera.GetFocus();
            Actor screen = camera.GetScreen();

            if (image == focus || image.Overlaps(screen))
            {
                Vector2 position = image.GetCenter() - camera.GetPosition();
                Vector2 originalSize = image.GetOriginalSize();
                Vector2 size = image.GetSize();
                
                Texture2D texture = GetRaylibTexture(image.GetFile());
                Rectangle source = new Rectangle(0, 0, originalSize.X, originalSize.Y);
                Rectangle destination = new Rectangle(position.X, position.Y, size.X, size.Y);
                Vector2 origin = new Vector2(size.X / 2, size.Y / 2);
                float rotation = image.GetRotation();
                Raylib_cs.Color tint = GetRaylibColor(image.GetTint());
                
                Raylib.DrawTexturePro(texture, source, destination, origin, rotation, tint);
            }
        }

        public void Draw(Label label)
        {
            Raylib_cs.Font font = GetRaylibFont(label.GetFontFile());   
            string text = label.GetText();
            Vector2 position = label.GetPosition();
            float fontSize = label.GetFontSize();
            float spacing = 2f;
            Raylib_cs.Color color = GetRaylibColor(label.GetFontColor());
            
            int alignment = label.GetAlignment();
            Vector2 size = Raylib.MeasureTextEx(font, text, fontSize, spacing);
            if (alignment == Label.Right) position.X = position.X - size.X;
            if (alignment == Label.Center) position.X = position.X - (size.X / 2);
            label.SizeTo(size);

            Raylib.DrawTextEx(font, text, position, fontSize, spacing, color);
        }

        public void Draw(Label label, Camera camera)
        {
            Actor focus = camera.GetFocus();
            Actor screen = camera.GetScreen();

            if (label == focus || label.Overlaps(screen))
            {
                Raylib_cs.Font font = GetRaylibFont(label.GetFontFile());   
                string text = label.GetText();
                Vector2 position = label.GetPosition() - camera.GetPosition();
                float fontSize = label.GetFontSize();
                float spacing = 2f;
                Raylib_cs.Color color = GetRaylibColor(label.GetFontColor());
                
                int alignment = label.GetAlignment();
                Vector2 size = Raylib.MeasureTextEx(font, text, fontSize, spacing);
                if (alignment == Label.Right) position.X = position.X - size.X;
                if (alignment == Label.Center) position.X = position.X - (size.X / 2);
                label.SizeTo(size);

                Raylib.DrawTextEx(font, text, position, fontSize, spacing, color);
            }
        }

        public void Draw(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                Draw(actor);
            }
        }

        public void Draw(List<Actor> actors, Camera camera)
        {
            foreach (Actor actor in actors)
            {
                Draw(actor, camera);
            }
        }

        public void Draw(List<Casting.Image> images)
        {
            foreach (Casting.Image image in images)
            {
                Draw(image);
            }
        }
        public void Draw(List<Casting.Image> images, Camera camera)
        {
            foreach (Casting.Image image in images)
            {
                Draw(image, camera);
            }
        }

        public void Draw(List<Label> labels)
        {
            foreach (Label label in labels)
            {
                Draw(label);
            }
        }

        public void Draw(List<Label> labels, Camera camera)
        {
            foreach (Label label in labels)
            {
                Draw(label, camera);
            }
        }

        public void DrawGrid(int cellSize, Casting.Color color)
        {
            Raylib_cs.Color raylibColor = GetRaylibColor(color);
            int width = _settings.GetInt("screenWidth");
            int height = _settings.GetInt("screenHeight");
            
            for (int x = 0; x < width; x += cellSize)
            {
                Raylib.DrawLine(x, 0, x, height, raylibColor);
            }
            for (int y = 0; y < height; y += cellSize)
            {
                Raylib.DrawLine(0, y, width, y, raylibColor);
            }
        }

        public void DrawGrid(int cellSize, Casting.Color color, Camera camera)
        {
            Vector2 position = camera.GetPosition();
            Raylib_cs.Color raylibColor = GetRaylibColor(color);
            int width = (int) camera.GetWorld().GetWidth();
            int height = (int) camera.GetWorld().GetHeight();

            for (int x = 0; x < width; x += cellSize)
            {
                int newX = x - (int)position.X;
                Raylib.DrawLine(newX, 0, newX, height, raylibColor);
            }
            for (int y = 0; y < height; y += cellSize)
            {
                int newY = y - (int)position.Y;
                Raylib.DrawLine(0, newY, width, newY, raylibColor);
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
                string caption = _settings.GetString("screenCaption");
                int width = _settings.GetInt("screenWidth");
                int height = _settings.GetInt("screenHeight");
                int frameRate = _settings.GetInt("frameRate");
                
                Raylib.InitWindow(width, height, caption);
                Raylib.SetTargetFPS(frameRate);
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

        private Raylib_cs.Color GetRaylibColor(Casting.Color color)
        {
            Tuple<byte, byte, byte, byte> tuple = color.ToTuple();
            return new Raylib_cs.Color(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        }

        private Raylib_cs.Font GetRaylibFont(string posixFilepath)
        {
            Raylib_cs.Font font = Raylib.GetFontDefault();
            string filepath = posixFilepath.Replace('/', Path.DirectorySeparatorChar);
            if (filepath != string.Empty && !_fonts.ContainsKey(filepath))
            {
                _fonts[filepath] = Raylib.LoadFont(filepath);
                font = _fonts[filepath];
            }
            return font;
        }

        private Raylib_cs.Texture2D GetRaylibTexture(string posixFilepath)
        {
            string filepath = posixFilepath.Replace('/', Path.DirectorySeparatorChar);
            if (!_textures.ContainsKey(filepath))
            {
                _textures[filepath] = Raylib.LoadTexture(filepath);
            }
            return _textures[filepath];
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