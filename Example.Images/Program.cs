using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Images
{
    /// <summary>
    /// The entry point for the program.
    /// </summary>
    /// <remarks>
    /// The purpose of this program is to demonstrate how Actors, Actions, Services and a Director 
    /// work together to draw both static and animated images on the screen.
    /// </remarks>
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Instantiate a service factory for other objects to use.
            IServiceFactory serviceFactory = new RaylibServiceFactory();

            // Instantiate the actors that are the focus of this example.
            // Create a static robot.
            Image robot1 = new Image();
            robot1.SizeTo(96, 96);
            robot1.MoveTo(176, 192);
            robot1.Display("Assets/robot0.png");

            // Create an animated robot.
            string[] filePaths = new string[6];
            filePaths[0] = "Assets/robot1.png";
            filePaths[1] = "Assets/robot2.png";
            filePaths[2] = "Assets/robot3.png";
            filePaths[3] = "Assets/robot4.png";
            filePaths[4] = "Assets/robot5.png";
            filePaths[5] = "Assets/robot6.png";

            float durationInSeconds = 0.3f; 
            int framesPerSecond = 60; 

            Image robot2 = new Image();
            robot2.SizeTo(96, 96);
            robot2.MoveTo(368, 192);
            robot2.Animate(filePaths, durationInSeconds, framesPerSecond);

            // Instantiate the action that will do the actual drawing.
            DrawImageAction drawImageAction = new DrawImageAction(serviceFactory);

            // Instantiate a new scene and add the actors and actions.
            Scene scene = new Scene();
            scene.AddActor("robots", robot1);
            scene.AddActor("robots", robot2);
            scene.AddAction(Phase.Output, drawImageAction);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
