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

        private int _maxX = 370;
        private int _maxY = 370;


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
                float x = random.Next(0, _height - ballRadius);
                float y = random.Next(0, _width - ballRadius);

                int SpeedX;
                do
                {
                    SpeedX = random.Next(-3, 3);
                } while (SpeedX == 0);

                int SpeedY;
                do
                {
                    SpeedY = random.Next(-3, 3);
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
            bool isCorrectInX = (ball.getPosition().X + ball.getR() + ball.getSpeed().X < _maxX /*- 2 * ball.getR()*/) && (ball.getPosition().X + ball.getSpeed().X /*- ball.getR()*/ > 0);
            bool isCorrectInY = (ball.getPosition().Y + ball.getR() + ball.getSpeed().Y < _maxY /*- 2 * ball.getR()*/) && (ball.getPosition().Y + ball.getSpeed().Y /*- ball.getR()*/ > 0);
            if (!isCorrectInX)
            {
                ball.setSpeed(-ball.getSpeed().X, ball.getSpeed().Y);
            }
            if (!isCorrectInY)
            {
                ball.setSpeed(ball.getSpeed().X, -ball.getSpeed().Y);
            }
        }

        public override void removeBalls()
        {
            isMoving = false;
            _balls.Clear();
        }
        public override void startMoving()
        {
            isMoving = true;
            Task.Run(() =>
            {
                while (isMoving)
                {
                    foreach (BallAPI ballAPI in ballAPIs)
                    {
                        ballAPI.MakeMove(_maxX, _maxY);
                        Thread.Sleep(3);
                    }
                }
            });
        }
    }

}