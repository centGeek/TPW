using Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;

//using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Logic

{
    internal class LogicBoard : LogicBoardAPI
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
                dataBall.ChangedPosition += CheckBallCollisions;
                dataBall.ChangedPosition += checkBorderCollision;

                ballAPIs.Add(dataBall);

                _balls.Add(ball);
            }
        }

        public override void CheckBallCollisions(object s, DataEventArgsAPI e)
        {
            BallAPI ball = (BallAPI)s;
            List<BallAPI> collidingBalls = new List<BallAPI>();
            Monitor.Enter(ball.GetLockedObject());
            try
            {
                foreach (BallAPI otherBall in dataAPI.GetAllBalls())
                {
                    //Zwykły Pitagoras z "wyprzedzeniem" ruchu
                    double distance = Math.Sqrt(Math.Pow(ball.getPosition().X + ball.getSpeed().X - (otherBall.getPosition().X + otherBall.getSpeed().X), 2)
                                    + Math.Pow(ball.getPosition().Y + ball.getSpeed().Y - (otherBall.getPosition().Y + otherBall.getSpeed().Y), 2));
                    if (otherBall != ball && distance <= ball.getR())
                    {
                        collidingBalls.Add(otherBall);
                    }
                }
                foreach (BallAPI otherBall in collidingBalls)
                {
                    Debug.WriteLine("Dochodzi do zderzenia");
                    float otherBallXSpeed = otherBall.getSpeed().X * (otherBall.Mass - ball.Mass) / (otherBall.Mass + ball.Mass)
                                            + ball.Mass * ball.getSpeed().X * 2f / (otherBall.Mass + ball.Mass);
                    float otherBallYSpeed = otherBall.getSpeed().Y * (otherBall.Mass - ball.Mass) / (otherBall.Mass + ball.Mass)
                                            + ball.Mass * ball.getSpeed().Y * 2f / (otherBall.Mass + ball.Mass);

                    float ballXSpeed = ball.getSpeed().X * (ball.Mass - otherBall.Mass) / (ball.Mass + ball.Mass)
                                        + otherBall.Mass * otherBall.getSpeed().X * 2f / (ball.Mass + otherBall.Mass);
                    float ballYSpeed = ball.getSpeed().Y * (ball.Mass - otherBall.Mass) / (ball.Mass + ball.Mass)
                                        + otherBall.Mass * otherBall.getSpeed().Y * 2f / (ball.Mass + otherBall.Mass);

                    otherBall.setSpeed(otherBallXSpeed, otherBallYSpeed);
                    ball.setSpeed(ballXSpeed, ballYSpeed);
                }
            }
            catch (SynchronizationLockException exception)
            {
                throw new Exception("Synchronization lock not working", exception);
            }
            finally
            {
                Monitor.Exit(ball.GetLockedObject());
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

        public override void checkBorderCollision(Object s, DataEventArgsAPI e)
        {
            BallAPI ball = (BallAPI)s;
            bool isCorrectInX = (ball.getPosition().X + ball.getR() + ball.getSpeed().X < _maxX) && (ball.getPosition().X + ball.getSpeed().X > 0);
            bool isCorrectInY = (ball.getPosition().Y + ball.getR() + ball.getSpeed().Y < _maxY) && (ball.getPosition().Y + ball.getSpeed().Y > 0);
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
            dataAPI.RemoveAllBalls();
            _balls.Clear();
            ballAPIs.Clear();
            Debug.WriteLine($"Logika po wyczyszczeniu sadzi ze ma {_balls.Count} a z modelu {ballAPIs.Count}");
        }
        /*public override void startMoving()
        {
            Debug.WriteLine($"Przed ruchem było tyle kulek {ballAPIs.Count()}");
            isMoving = true;
            Task t = Task.Run(() =>
            {
                long i = 0;
                while (isMoving)
                {
                    foreach (BallAPI kula in ballAPIs)
                    {
                        if (isMoving)
                        {
                            kula.MakeMove(_maxX, _maxY);

                        }
                        kula.MakeMove(_maxX, _maxY);
                        Thread.Sleep(1);
                    }
                    i++;
                    //Debug.WriteLine($"{i}");
                }
                Debug.WriteLine("Koniec petli, umieram");
            });

            if (t.IsCompleted)
            {
                Debug.WriteLine("Chyba udało sie zabic to ");
            }
        }*/
        public override void startMoving()
        {
            isMoving = true;
            foreach (BallAPI ball in ballAPIs)
            {
                Task.Run(() =>
                {
                    while (isMoving)
                    {
                        //ball.MakeMove(_maxX, _maxY);
                        Thread.Sleep(15);
                    }
                });

            }
        }
        //private void OnTimedEvent(Object source, ElapsedEventArgs e)
        //{
        //   BallAPI temp = (BallAPI)source;
        //    temp.MakeMove();
        //}



    }
}