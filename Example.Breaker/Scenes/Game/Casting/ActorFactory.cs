using System;
using System.Numerics;
using Byui.Games.Casting;
using Byui.Games.Services;


namespace Example.Breaker.Game
{
    public class ActorFactory
    {
        private ISettingsService _settingsService;

        public ActorFactory(ISettingsService settingsService) 
        {
            _settingsService = settingsService;
        }

        public Ball CreateBall()
        {
            string image = _settingsService.GetString("ballImage");
            float width = _settingsService.GetFloat("ballWidth");
            float height = _settingsService.GetFloat("ballHeight");
            float x = _settingsService.GetFloat("ballX");
            float y = _settingsService.GetFloat("ballY");
            float directionX = _settingsService.GetFloat("ballVelocity");
            float directionY = directionX *= -1;

            Ball ball = new Ball();
            ball.Display(image);
            ball.SizeTo(width, height);
            ball.MoveTo(x, y);
            ball.Steer(directionX, directionY);

            return ball;
        }

        public Actor CreateField()
        {
            float width = _settingsService.GetFloat("fieldWidth");
            float height = _settingsService.GetFloat("fieldHeight");
            float x = _settingsService.GetFloat("fieldX");
            float y = _settingsService.GetFloat("fieldY");

            Actor field = new Actor();
            field.SizeTo(width, height);
            field.MoveTo(x, y);

            return field;
        }

        public Level CreateLevel()
        {
            Level level = new Level();
            level.MoveTo(0, 0);
            level.Align(Label.Left);
            return level;
        }

        public Lives CreateLives()
        {
            int x = _settingsService.GetInt("screenWidth");
            int startingLives = _settingsService.GetInt("startingLives");
            
            Lives lives = new Lives(startingLives);
            lives.MoveTo(x, 0);
            lives.Align(Label.Right);

            return lives;
        }

        public Paddle CreatePaddle()
        {
            string[] images = _settingsService.GetArray<string>("paddleImages");
            float durationInSeconds = _settingsService.GetFloat("paddleAnimationLength");
            int framesPerSecond = _settingsService.GetInt("frameRate");
            float width = _settingsService.GetFloat("paddleWidth");
            float height = _settingsService.GetFloat("paddleHeight");
            float x = _settingsService.GetFloat("paddleX");
            float y = _settingsService.GetFloat("paddleY");
            
            Paddle paddle = new Paddle();
            paddle.Animate(images, durationInSeconds, framesPerSecond);
            paddle.SizeTo(width, height);
            paddle.MoveTo(x, y);

            return paddle;
        }

        public Score CreateScore()
        {
            int x = (int) _settingsService.GetFloat("screenWidth") / 2;
            int startingLives = _settingsService.GetInt("startingLives");
            
            Score score = new Score();
            score.MoveTo(x, 0);
            score.Align(Label.Center);

            return score;
        }
        
    }
}