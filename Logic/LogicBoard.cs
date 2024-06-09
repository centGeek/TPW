using Data;
using System.Diagnostics;


namespace Logic

{
    internal class LogicBoard : LogicBoardAPI
    {
        private int _height { get; set; }
        private int _width { get; set; }
        private List<LogicBallAPI> _balls { get; set; }

        private static object _lock = new object();

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
            lock (_lock)
            {
                for (int i = 0; i < ballsQuantity; i++)
                {
                    Random random = new Random();
                    bool wrongPlacement = false; //flaga informujaca o nachodzacych kulach
                    float x = random.Next(0, _width - 2 * ballRadius);
                    float y = random.Next(0, _height - 2 * ballRadius);
                    foreach (LogicBall otherBall in _balls)
                    {
                        double distance = Math.Sqrt(Math.Pow(x - (otherBall.X), 2)
                                        + Math.Pow(y - (otherBall.Y), 2));
                        if (!(distance > 2 * ballRadius))
                        {
                            Debug.WriteLine("Wykryto błedne początkowe położenie");
                            wrongPlacement = true;
                            break;
                        }
                    }
                    int SpeedX;
                    int SpeedY;

                    if (wrongPlacement) { i--; continue; } //Dzieki temu kule nie powinny pojawiać się w sobie
                    do
                    {
                        SpeedX = random.Next(-2, 2);
                    } while (SpeedX == 0);
                    do
                    {
                        SpeedY = random.Next(-2, 2);
                    } while (SpeedY == 0);

                    BallAPI dataBall = dataAPI.AddBall(x, y, SpeedX, SpeedY, ballRadius);
                    PositionOfBall recordedPosition = dataBall.getPosition();

                    LogicBall ball = new LogicBall(recordedPosition.X, recordedPosition.Y, ballRadius);

                    dataBall.ChangedPosition += AllChecksInOne;
                    //Nie da się tego wrzucić do AllCheck bo jest tu kula z logiki
                    dataBall.ChangedPosition += ball.UpdateBall;


                    ballAPIs.Add(dataBall);

                    _balls.Add(ball);
                }
            }
        }
        private void AllChecksInOne(object s, DataEventArgsAPI e)
        {
            lock (_lock)
            {
                CheckBallCollisions(s, e);
                checkBorderCollision(s, e);
            }
        }
        private void CheckBallCollisions(object s, DataEventArgsAPI e)
        {
            BallAPI ball = (BallAPI)s;
            List<BallAPI> collidingBalls = new List<BallAPI>();
            //Monitor.Enter(ball.GetLockedObject());

            PositionOfBall ballPosition = e.positionOfBall;
            SpeedOfBall ballSpeed = e.speedOfBall;
            long time = e.moveTime;

            foreach (BallAPI otherBall in dataAPI.GetAllBalls())
            {
                //Zwykły Pitagoras z "wyprzedzeniem" ruchu
                //Korzystamy z rekordów stąd najpierw pobieramy
                //Kule i tak się nie poruszją z racji na wejście do monitora

                PositionOfBall otherBallPosition = otherBall.getPosition();
                SpeedOfBall otherBallSpeed = otherBall.getSpeed();

                double distance = Math.Sqrt(Math.Pow(ballPosition.X + ballSpeed.X * time - (otherBallPosition.X + otherBallSpeed.X * time), 2)
                                + Math.Pow(ballPosition.Y + ballSpeed.Y * time - (otherBallPosition.Y + otherBallSpeed.Y * time), 2));
                if ((otherBall != ball) && (distance <= 2.0 * e.radius))
                {
                    collidingBalls.Add(otherBall);
                }
            }
            foreach (BallAPI otherBall in collidingBalls)
            {
                PositionOfBall otherBallPosition = otherBall.getPosition();
                SpeedOfBall otherBallSpeed = otherBall.getSpeed();


                //Debug.WriteLine("Dochodzi do zderzenia");
                float otherBallXSpeed = otherBallSpeed.X * (otherBall.Mass - ball.Mass) / (otherBall.Mass + ball.Mass)
                                        + ball.Mass * ballSpeed.X * 2f / (otherBall.Mass + ball.Mass);
                float otherBallYSpeed = otherBallSpeed.Y * (otherBall.Mass - ball.Mass) / (otherBall.Mass + ball.Mass)
                                        + ball.Mass * ballSpeed.Y * 2f / (otherBall.Mass + ball.Mass);

                float ballXSpeed = ballSpeed.X * (ball.Mass - otherBall.Mass) / (ball.Mass + ball.Mass)
                                    + otherBall.Mass * otherBallSpeed.X * 2f / (ball.Mass + otherBall.Mass);
                float ballYSpeed = ballSpeed.Y * (ball.Mass - otherBall.Mass) / (ball.Mass + ball.Mass)
                                    + otherBall.Mass * otherBallSpeed.Y * 2f / (ball.Mass + otherBall.Mass);

                otherBall.setSpeed(otherBallXSpeed, otherBallYSpeed);
                ball.setSpeed(ballXSpeed, ballYSpeed);
            }
        }


        public override int GetHeight()
        {
            return _height;
        }

        public override void SetHeight(int height)
        {
            _height = height;
        }

        public override int GetWidth()
        {
            return _width;
        }

        public override void SetWidth(int width)
        {
            _width = width;
        }

        private void checkBorderCollision(Object s, DataEventArgsAPI e)
        {
            BallAPI ball = (BallAPI)s;

            PositionOfBall ballPosition = e.positionOfBall;
            SpeedOfBall ballSpeed = e.speedOfBall;
            int r = e.radius;
            long time = e.moveTime;

            bool isCorrectInX = (ballPosition.X + r + ballSpeed.X * time < _maxX - r) && (ballPosition.X + ballSpeed.X * time > 0);
            bool isCorrectInY = (ballPosition.Y + r + ballSpeed.Y * time < _maxY - r) && (ballPosition.Y + ballSpeed.Y * time > 0);
            if (!isCorrectInX)
            {
                ball.setSpeed(-ballSpeed.X, ballSpeed.Y);
            }
            if (!isCorrectInY)
            {
                ball.setSpeed(ballSpeed.X, -ballSpeed.Y);
            }
        }

        public override void removeBalls()
        {
            if (ballAPIs.Count() >= 1)
            {
                lock (_lock)
                {
                    _balls.Clear();
                    ballAPIs.Clear();
                }
                //Monitor.Enter(ballAPIs[0].GetLockedObject());
                dataAPI.RemoveAllBalls();
                //Monitor.Exit(ballAPIs[0].GetLockedObject());

                Debug.WriteLine($"Logika po wyczyszczeniu sadzi ze ma {_balls.Count} a z modelu {ballAPIs.Count}");
            }
            else
            {
                Debug.WriteLine("Nie było nic do czyszcenia.");
            }
        }

        //private void OnTimedEvent(Object source, ElapsedEventArgs e)
        //{
        //   BallAPI temp = (BallAPI)source;
        //    temp.MakeMove();
        //}
    }
}