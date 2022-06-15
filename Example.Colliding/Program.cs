using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Colliding
{
    /// <summary>
    /// The entry point for the program.
    /// </summary>
    /// <remarks>
    /// The purpose of this program is to demonstrate how Actors, Actions, Services and a Director 
    /// work together to rotate an actor on the screen.
    /// </remarks>
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Instantiate a service factory for other objects to use.
            IServiceFactory serviceFactory = new RaylibServiceFactory();

            // Instantiate the actors that are used in this example.
            Actor actor1 = new Actor();
            actor1.SizeTo(100, 100);
            actor1.MoveTo(270, 190);
            actor1.Tint(Color.Blue());
            actor1.Steer(-3, 0);

            Actor actor2 = new Actor();
            actor2.SizeTo(50, 50);
            actor2.MoveTo(270, 215);
            actor2.Tint(Color.Red());
            actor2.Steer(6, 0);

            Actor screen = new Actor();
            screen.SizeTo(640, 480);
            screen.MoveTo(0, 0);

            // Instantiate the actions that use the actors.
            CollideActorsAction collideActorsAction = new CollideActorsAction(serviceFactory);
            MoveActorsAction moveActorsAction = new MoveActorsAction(serviceFactory);
            DrawActorsAction drawActorsAction = new DrawActorsAction(serviceFactory);

            // Instantiate a new scene, add the actors and actions.
            Scene scene = new Scene();
            scene.AddActor("actor1", actor1);
            scene.AddActor("actor2", actor2);
            scene.AddActor("screen", screen);
            scene.AddAction(Phase.Update, moveActorsAction);
            scene.AddAction(Phase.Update, collideActorsAction);
            scene.AddAction(Phase.Output, drawActorsAction);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
