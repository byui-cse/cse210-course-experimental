using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Rotating
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
            Label label = new Label();
            label.Display("'a' or 'd' to rotate");
            label.MoveTo(25, 25);
            
            Actor actor = new Actor();
            actor.SizeTo(100, 100);
            actor.MoveTo(270, 190);
            actor.Tint(Color.Blue());

            // Instantiate the actions that use the actors.
            RotateActorAction rotateActorAction = new RotateActorAction(serviceFactory);
            DrawActorAction drawActorAction = new DrawActorAction(serviceFactory);

            // Add them all within a new instance of Scene.
            Scene scene = new Scene();
            scene.AddActor("actors", actor);
            scene.AddActor("labels", label);
            scene.AddAction(Phase.Input, rotateActorAction);
            scene.AddAction(Phase.Output, drawActorAction);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
