using Data;
using System.ComponentModel;
using System.Diagnostics;
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
                dataBall.ChangedPosition += checkBorderCollision;

                ballAPIs.Add(dataBall);

                _balls.Add(ball);
            }
        }

        public void CheckBallCollisions(object sender, PropertyChangedEventArgs e)
        {   //TODO tutaj sobie wracam jutro
            BallAPI ball = (BallAPI)sender;
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
            Thread.Sleep(80);
            _balls.Clear();
            ballAPIs.Clear();
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
                        ball.MakeMove(_maxX, _maxY);
                        Thread.Sleep(4);
                    }
                });

            }
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            BallAPI temp = (BallAPI)source;
            temp.MakeMove(_maxX, _maxY);
        }



    }
}