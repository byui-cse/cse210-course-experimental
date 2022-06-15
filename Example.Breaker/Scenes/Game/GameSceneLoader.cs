using System;
using System.Collections.Generic;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Example.Breaker.Shared;


namespace Example.Breaker.Game
{
    public class GameSceneLoader : SceneLoader
    {

        private ActorFactory _actorFactory;

        public GameSceneLoader(IServiceFactory serviceFactory) : base(serviceFactory) 
        {
            ISettingsService settingsService = serviceFactory.GetSettingsService();
            _actorFactory = new ActorFactory(settingsService);
        }

        public override void Load(Scene scene)
        {
            scene.Clear();
            LoadBackground(scene);
            LoadActors(scene);
            LoadActions(scene);
        }

        private void LoadActions(Scene scene)
        {
            IServiceFactory serviceFactory = GetServiceFactory();
            
            SteerActorsAction steerActorsAction = new SteerActorsAction(serviceFactory);
            MoveActorsAction moveActorsAction = new MoveActorsAction(serviceFactory);
            CollideActorsAction collideActorsAction = new CollideActorsAction(serviceFactory);
            LoadSceneAction loadSceneAction = new LoadSceneAction(serviceFactory);
            DrawActorsAction drawActorsAction = new DrawActorsAction(serviceFactory);

            scene.AddAction(Phase.Input, steerActorsAction);
            scene.AddAction(Phase.Update, moveActorsAction);
            scene.AddAction(Phase.Update, collideActorsAction);
            scene.AddAction(Phase.Update, loadSceneAction);
            scene.AddAction(Phase.Output, drawActorsAction);
        }

        private void LoadActors(Scene scene)
        {
            Ball ball = _actorFactory.CreateBall();
            Paddle paddle = _actorFactory.CreatePaddle();
            Actor field = _actorFactory.CreateField();
            Level level = _actorFactory.CreateLevel();
            Score score = _actorFactory.CreateScore();
            Lives lives = _actorFactory.CreateLives();

            paddle.AttachBall(ball);

            scene.AddActor("balls", ball);
            scene.AddActor("paddle", paddle);
            scene.AddActor("field", field);
            scene.AddActor("level", level);
            scene.AddActor("score", score);
            scene.AddActor("lives", lives);
        }

        private void LoadBackground(Scene scene)
        {
            IServiceFactory serviceFactory = GetServiceFactory();
            ISettingsService settingsService = serviceFactory.GetSettingsService();
            IVideoService videoService = serviceFactory.GetVideoService();
            videoService.SetBackground(Color.Black());
        }

    }
}

