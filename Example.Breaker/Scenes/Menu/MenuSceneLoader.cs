using System;
using System.IO.Enumeration;
using System.Numerics;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Example.Breaker.Shared;

namespace Example.Breaker.Menu
{
    public class MenuSceneLoader : SceneLoader
    {
        public MenuSceneLoader(IServiceFactory serviceFactory) : base(serviceFactory) { }

        public override void Load(Scene scene)
        {
            scene.Clear();
            LoadBackground(scene);
            LoadTitle(scene);
            LoadInstructions(scene);
            LoadCourse(scene);
            LoadUniversity(scene);
            LoadActions(scene);
        }

        private void LoadBackground(Scene scene)
        {
            IServiceFactory serviceFactory = GetServiceFactory();
            ISettingsService settingsService = serviceFactory.GetSettingsService();
            IVideoService videoService = serviceFactory.GetVideoService();
            videoService.SetBackground(Color.Black());
        }

        private void LoadTitle(Scene scene)
        {
            IServiceFactory serviceFactory = GetServiceFactory();
            ISettingsService settingsService = serviceFactory.GetSettingsService();
            IVideoService videoService = serviceFactory.GetVideoService();

            string file = settingsService.GetString("splashImage");
            int width = settingsService.GetInt("splashWidth");
            int height = settingsService.GetInt("splashHeight");
            
            Image image = new Image();
            image.Display(file);
            image.MoveTo(0, 0);
            image.SizeTo(width, height);

            scene.AddActor("images", image);
        }

        private void LoadInstructions(Scene scene)
        {
            IServiceFactory serviceFactory = GetServiceFactory();
            ISettingsService settingsService = serviceFactory.GetSettingsService();
            
            string font = settingsService.GetString("fontFile");
            string text = settingsService.GetString("instructionsText");
            int fontSize = settingsService.GetInt("instructionsFontSize");
            int x = settingsService.GetInt("instructionsX");
            int y = settingsService.GetInt("instructionsY");

            Label label = new Label();
            label.Display(text);
            label.MoveTo(x, y);
            label.Align(Label.Center);
            label.SetFont(font, fontSize, Color.Green());

            scene.AddActor("labels", label);
        }

        private void LoadCourse(Scene scene)
        {
            IServiceFactory serviceFactory = GetServiceFactory();
            ISettingsService settingsService = serviceFactory.GetSettingsService();
            
            string font = settingsService.GetString("fontFile");
            string text = settingsService.GetString("courseText");
            int fontSize = settingsService.GetInt("courseFontSize");
            int x = settingsService.GetInt("courseX");
            int y = settingsService.GetInt("courseY");

            Label label = new Label();
            label.Display(text);
            label.MoveTo(x, y);
            label.Align(Label.Center);
            label.SetFont(font, fontSize, Color.White());

            scene.AddActor("labels", label);
        }

        private void LoadUniversity(Scene scene)
        {
            IServiceFactory serviceFactory = GetServiceFactory();
            ISettingsService settingsService = serviceFactory.GetSettingsService();
            
            string font = settingsService.GetString("fontFile");
            string text = settingsService.GetString("universityText");
            int fontSize = settingsService.GetInt("universityFontSize");
            int x = settingsService.GetInt("universityX");
            int y = settingsService.GetInt("universityY");

            Label label = new Label();
            label.Display(text);
            label.MoveTo(x, y);
            label.Align(Label.Center);
            label.SetFont(font, fontSize, Color.White());

            scene.AddActor("labels", label);
        }

        private void LoadActions(Scene scene)
        {
            IServiceFactory serviceFactory = GetServiceFactory();
            
            LoadSceneAction loadSceneAction = new LoadSceneAction(serviceFactory);
            DrawActorsAction drawActorsAction = new DrawActorsAction(serviceFactory);
            PlayMusicAction playMusicAction = new PlayMusicAction(serviceFactory);

            scene.AddAction(Phase.Input, loadSceneAction);
            scene.AddAction(Phase.Output, drawActorsAction);
            scene.AddAction(Phase.Output, playMusicAction);
        }
    }
}

