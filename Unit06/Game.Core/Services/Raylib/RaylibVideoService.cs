using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Reflection;
using Byui.Game.Casting;
using Raylib_cs;


namespace Byui.Game.Services
{
    public class RaylibVideoService : IVideoService
    {
        private static readonly string[] FontPatterns
            = new string[] { "*.ttf", "*.otf" };

        private static readonly string[] ImagePatterns 
            = new string[] { "*.png", "*.gif", "*.jpg", "*.bmp" };

        private Dictionary<string, Raylib_cs.Font> _fonts
            = new Dictionary<string, Raylib_cs.Font>();
        
        private Dictionary<string, Raylib_cs.Texture2D> _textures
            = new Dictionary<string, Raylib_cs.Texture2D>();
        
        private string _caption = string.Empty;
        private int _width = 480;
        private int _height = 640;
        private Raylib_cs.Color _backgroundColor = Raylib_cs.Color.WHITE;
        
        public RaylibVideoService(string caption, int width, int height)
        {
            _caption = caption;
            _width = width;
            _height = height;
        }

        public RaylibVideoService(string caption, int width, int height, 
                Casting.Color backgroundColor)
        {
            _caption = caption;
            _width = width;
            _height = height;
            _backgroundColor = ToRaylibColor(backgroundColor);
        }

        public void ClearBuffer()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(_backgroundColor);
        }

        public void Draw(ImageActor actor, double alpha)
        {
            string file = actor.GetImage();
            if (!_textures.ContainsKey(file))
            {
                throw new ArgumentException($"{file} has not been loaded.");
            }

            Raylib_cs.Texture2D texture = _textures[file];
            Point position = actor.Interpolate(alpha);
            int x = position.GetX();
            int y = position.GetY();
            
            Raylib.DrawTexture(texture, x, y, Raylib_cs.Color.WHITE);
        }

        public void Draw(LabelActor actor, double alpha)
        {
            string file = actor.GetFont();
            if (!_fonts.ContainsKey(file))
            {
                throw new ArgumentException($"{file} has not been loaded.");
            }

            Raylib_cs.Font raylibFont = _fonts[file];
            string text = actor.GetText();
            int fontSize = actor.GetFontSize();
            int alignment = actor.GetAlignment();
            Raylib_cs.Color raylibColor = ToRaylibColor(actor.GetColor());
            
            Point position = actor.Interpolate(alpha);
            int x = CalcutePosition(raylibFont, text, fontSize, position.GetX(), alignment);
            int y = position.GetY();
            Vector2 vector = new Vector2(x, y);

            Raylib.DrawTextEx(raylibFont, text, vector, fontSize, 0, raylibColor);
        }

        public void FlushBuffer()
        {
            Raylib.EndDrawing(); 
        }

        public void Initialize()
        {
            Raylib.InitWindow(_width, _height, _caption);
        }

        public bool IsWindowOpen()
        {
            return !Raylib.WindowShouldClose();
        }

        public void LoadFonts(string directory)
        {
            List<string> paths = FileUtil.GetFilepaths(directory, FontPatterns);
            foreach (string path in paths)
            {
                string file = Path.GetFileName(path);
                _fonts[file] = Raylib.LoadFont(path);
            }
        }

        public void LoadImages(string directory)
        {
            List<string> paths = FileUtil.GetFilepaths(directory, ImagePatterns);
            foreach (string path in paths)
            {
                string file = Path.GetFileName(path);
                _textures[file] = Raylib.LoadTexture(path);
            }
        }

        public void Release()
        {
            if (!Raylib.WindowShouldClose())
            {
                Raylib.CloseWindow();
            }
        }

        public void UnloadFonts()
        {
            foreach (string key in _fonts.Keys)
            {
                Raylib_cs.Font raylibFont = _fonts[key];
                Raylib.UnloadFont(raylibFont);
            }
        }

        public void UnloadImages()
        {
            foreach (string key in _textures.Keys)
            {
                Raylib_cs.Texture2D raylibTexture = _textures[key];
                Raylib.UnloadTexture(raylibTexture);
            }
        }

        private int CalcutePosition(Font font, string text, int fontSize, int x, int alignment)
        {
            Vector2 size = Raylib.MeasureTextEx(font, text, fontSize, 0);
            int width = (int)size.X;
            
            if (alignment == LabelActor.Center)
            {
                x = x - (width / 2);
            }
            else if (alignment == LabelActor.Right)
            {
                x = x - width;
            }
            return x;
        }

        private Raylib_cs.Color ToRaylibColor(Casting.Color color)
        {
            int r = color.GetR();
            int g = color.GetG();
            int b = color.GetB();
            return new Raylib_cs.Color(r, g, b, System.Convert.ToByte(255));
        }

    }
}