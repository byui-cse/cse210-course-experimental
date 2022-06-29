using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Scaling
{
    /// <summary>
    /// The entry point for the program.
    /// </summary>
    /// <remarks>
    /// The purpose of this program is to demonstrate how Actors, Actions, Services and a Director 
    /// work together to scale an actor up and down on the screen.
    /// </remarks>
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Instantiate a service factory for other objects to use.
            IServiceFactory serviceFactory = new RaylibServiceFactory();

            // Instantiate the actors that are used in this example.
            Label label = new Label();
            label.Display("'w' or 's' to scale");
            label.MoveTo(25, 25);
            
            Actor actor = new Actor();
            actor.SizeTo(100, 100);
            actor.MoveTo(270, 190);
            actor.Tint(Color.Blue());

            // Instantiate the actions that use the actors.
            ScaleActorAction scaleActorAction = new ScaleActorAction(serviceFactory);
            DrawActorAction drawActorAction = new DrawActorAction(serviceFactory);

            // Instantiate a new scene, add the actors and actions.
            Scene scene = new Scene();
            scene.AddActor("actors", actor);
            scene.AddActor("labels", label);
            scene.AddAction(Phase.Input, scaleActorAction);
            scene.AddAction(Phase.Output, drawActorAction);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
