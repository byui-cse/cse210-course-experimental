using System;
using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Sounds
{
    /// <summary>
    /// The entry point for the program.
    /// </summary>
    /// <remarks>
    /// The purpose of this program is to demonstrate how Actors, Actions, Services and a Director 
    /// work together to play short and long sounds in a game.
    /// </remarks>
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Instantiate a service factory for other objects to use.
            IServiceFactory serviceFactory = new RaylibServiceFactory();

            // Instantiate the actors that are used in this example.
            Random random = new Random();

            Actor actor = new Actor();
            actor.SizeTo(50, 50);
            actor.MoveTo(270, 215);
            actor.Steer(-5, -5);
            actor.Tint(Color.Blue());

            Actor screen = new Actor();
            screen.SizeTo(640, 480);
            screen.MoveTo(0, 0);

            // Instantiate the actions that use the actors.
            MoveActorsAction moveActorsAction = new MoveActorsAction(serviceFactory);
            DrawActorsAction drawActorsAction = new DrawActorsAction(serviceFactory);
            PlayMusicAction playMusicAction = new PlayMusicAction(serviceFactory);

            // Instantiate a new scene, add the actors and actions.
            Scene scene = new Scene();
            scene.AddActor("actors", actor);
            scene.AddActor("screen", screen);
            scene.AddAction(Phase.Update, moveActorsAction);
            scene.AddAction(Phase.Output, drawActorsAction);
            scene.AddAction(Phase.Output, playMusicAction);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
