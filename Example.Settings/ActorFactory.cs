using System;
using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Settings
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public class ActorFactory
    {
        private ISettingsService _settingsService;

        public ActorFactory(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public Image CreateRobot(int startingX, int startingY)
        {
            int width = _settingsService.GetInt("robotWidth");
            int height = _settingsService.GetInt("robotHeight");
            string[] filePaths = _settingsService.GetArray<string>("robotWalking");
            float durationInSeconds = _settingsService.GetFloat("robotWalkingDuration");
            int framesPerSecond = _settingsService.GetInt("frameRate");
            
            Image robot = new Image();
            robot.SizeTo(width, height);
            robot.MoveTo(startingX, startingY);
            robot.Animate(filePaths, durationInSeconds, framesPerSecond);
            
            return robot;
        }
    }
}
