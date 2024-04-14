using Data;
using System.Diagnostics;
namespace Logic
{
    public class LogicBoard : LogicBoardAPI
    {
        private int _height { get; set; }
        private int _width { get; set; }
        private List<LogicBallAPI> _balls { get; set; }
        internal BoardAPI dataAPI;

        public LogicBoard(BoardAPI boardAPI)
        {
            this._height = boardAPI.Height;
            this._width = boardAPI.Width;
            _balls = new List<LogicBallAPI>();
            ballAPIs = new List<BallAPI>();
            dataAPI = boardAPI;

        }
        public override List<LogicBallAPI> getBalls()
        {
            return _balls;
        }

        private List<BallAPI> ballAPIs;

        public override void addBalls(int ballsQuantity, int ballRadius)
        {
            for (int i = 0; i < ballsQuantity; i++)
            {
                Random random = new Random();
                float x = random.Next(ballRadius, _height - ballRadius);
                float y = random.Next(ballRadius, _width - ballRadius);

                int SpeedX;
                do
                {
                    SpeedX = random.Next(-30, 33);
                } while (SpeedX == 0);

                int SpeedY;
                do
                {
                    SpeedY = random.Next(-33, 33);
                } while (SpeedY == 0);

                BallAPI dataBall = dataAPI.AddBall(x, y, SpeedX, SpeedY, ballRadius);
                LogicBall ball = new LogicBall(dataBall.getPosition().X, dataBall.getPosition().Y, ballRadius);


                dataBall.ChangedPosition += ball.UpdateBall;
                dataBall.ChangedPosition += checkBorderCollision;

                ballAPIs.Add(dataBall);

                _balls.Add(ball);
            }
        }

        public int GetHeight()
        {
            return _height;
        }

        public void SetHeight(int height)
        {
            _height = height;
        }

        public int GetWidth()
        {
            return _width;
        }

        public void SetWidth(int width)
        {
            _width = width;
        }

        public override void checkBorderCollision(Object s, DataEventArgs e)
        {
            BallAPI ball = (BallAPI)s;
            if (ball.getPosition().X + ball.getR() >= this._width || ball.getPosition().X + ball.getSpeed().X + ball.getR() >= this._width || ball.getPosition().X + ball.getR() >= 0 || ball.getPosition().X + ball.getSpeed().X + ball.getR() >= 0)
            {
                ball.setSpeed(-ball.getSpeed().X, ball.getSpeed().Y);

            }
            if (ball.getPosition().Y + ball.getR() >= this._height || ball.getPosition().Y + ball.getSpeed().Y + ball.getR() >= this.GetHeight() || ball.getPosition().Y + ball.getR() >= 0 || ball.getPosition().Y + ball.getSpeed().Y + ball.getR() >= 0)
            {
                ball.setSpeed(ball.getSpeed().X, -ball.getSpeed().Y);
            }
        }

        public override void removeBalls()
        {

            {
                for (int i = 0; i < 10; i++)
                {

                    foreach (BallAPI kula in ballAPIs)
                    {
                        kula.setPosition(0, 0);
                        kula.MakeMove();
                        Debug.WriteLine($"Poruszyłem kulą {kula.getPosition().ToString()}");
                        Thread.Sleep(100);

                    }
                    Debug.WriteLine(_balls[0].X);
                }
            }
            //_balls.Clear();
        }
    }

}