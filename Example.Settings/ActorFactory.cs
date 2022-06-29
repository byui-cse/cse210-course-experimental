using System;
using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Settings
{
    /// <summary>
    /// Creates actors for use in the game.
    /// </summary>
    public class ActorFactory
    {
        private ISettingsService _settingsService;

        public ActorFactory(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        /// <summary>
        /// Creates a robot using information found in the settings.json file. 
        /// </summary>
        /// <param name="startingX">The starting X position.</param>
        /// <param name="startingY">The starting Y position.</param>
        /// <returns>An instance of Image with robot settings.</returns>
        public Image CreateRobot(int startingX, int startingY)
        {
            // get the actor information from the settings.json file
            int width = _settingsService.GetInt("robotWidth");
            int height = _settingsService.GetInt("robotHeight");
            string[] filePaths = _settingsService.GetArray<string>("robotWalking");
            float durationInSeconds = _settingsService.GetFloat("robotWalkingDuration");
            int framesPerSecond = _settingsService.GetInt("frameRate");
            
            // create a new instance of image using the settings information
            Image robot = new Image();
            robot.SizeTo(width, height);
            robot.MoveTo(startingX, startingY);
            robot.Animate(filePaths, durationInSeconds, framesPerSecond);
            
            return robot;
        }
    }
}
