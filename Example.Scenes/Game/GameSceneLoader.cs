using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Example.Scenes.Shared;


namespace Example.Scenes.Game
{
    /// <summary>
    /// Loads the actors and actions required for the game scene.
    /// </summary>
    public class GameSceneLoader : SceneLoader
    {
        public GameSceneLoader(IServiceFactory serviceFactory) : base(serviceFactory) { }

        public override void Load(Scene scene)
        {
            // Set the backgroun color
            GetServiceFactory().GetVideoService().SetBackground(Color.Red());

            // Create the actors that participate in the scene.
            Label title = new Label();
            title.Display("GAME SCENE");
            title.MoveTo(320, 200);
            title.Align(Label.Center);

            Label instructions = new Label();
            instructions.Display("game over in -s");
            instructions.MoveTo(320, 240);
            instructions.Align(Label.Center);

            // Instantiate the actions that use the actors.
            IServiceFactory serviceFactory = GetServiceFactory();
            LoadSceneAction loadSceneAction = new LoadSceneAction(serviceFactory);
            DrawActorsAction drawActorsAction = new DrawActorsAction(serviceFactory);

            // Clear the given scene, add the actors and actions.
            scene.Clear();
            scene.AddActor("title", title);
            scene.AddActor("instructions", instructions);
            scene.AddAction(Phase.Update, loadSceneAction);
            scene.AddAction(Phase.Output, drawActorsAction);
        }
    }
}

