using System;
using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Settings
{
    /// <summary>
    /// The entry point for the program.
    /// </summary>
    /// <remarks>
    /// The purpose of this program is to demonstrate how to use a settings file, in combinated with
    /// Actors, Actions, Services and a Director, in your game.
    /// </remarks>
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Instantiate a service factory for other objects to use.
            IServiceFactory serviceFactory = new RaylibServiceFactory();

            // Get an instance of ISettingsService from the factory.
            ISettingsService settingsService = serviceFactory.GetSettingsService();
            
            // Instantiate the actor that is the focus of this example.
            // Note: the actor factory uses a settings service to get robot 
            // details from the settings.json file. 
            ActorFactory actorFactory = new ActorFactory(settingsService);
            Image robot = actorFactory.CreateRobot(272, 192);

            // Instantiate the action that will do the actual drawing.
            DrawActorsAction drawImageAction = new DrawActorsAction(serviceFactory);

            // Instantiate a new scene and add the actors and actions.
            Scene scene = new Scene();
            scene.AddActor("robots", robot);
            scene.AddAction(Phase.Output, drawImageAction);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
