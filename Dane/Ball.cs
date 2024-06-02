using System.Diagnostics;
using System.Numerics;
using System.Runtime.Versioning;

namespace Data
{
    internal class Ball : BallAPI
    {
        private Vector2 _position { get; set; }
        private Vector2 _speed { get; set; }
        private readonly int _r;
        private const int _m = 5;
        public override bool IsMoving { get; set; }

        public override int Mass { get { return _m; } }

        private static object _lockObject = new object();
        Stopwatch _stopwatch;

        public override PositionOfBall getPosition()
        {
            lock (_lockObject)
            {
                return new PositionOfBall(_position.X, _position.Y);
            }
        }
        public override SpeedOfBall getSpeed()
        {
            lock (_lockObject)
            {
                return new SpeedOfBall(_speed.X, _speed.Y);
            }
        }

        public override void setSpeed(float x, float y)
        {
            lock (_lockObject)
            {
                _speed = new Vector2(x, y);
            }
        }

        public override int getR()
        {
            return _r;
        }
        public override event EventHandler<DataEventArgsAPI> ChangedPosition;

        public Ball(Vector2 position, int r, Vector2 speed)
        {
            _speed = speed;
            _position = position;
            _r = r;
            _stopwatch = new Stopwatch();
            Thread thread = new Thread(StartMoving);
            thread.Start();
            IsMoving = true;
        }
        public Ball(Vector2 position, int r)
        {
            _speed = Vector2.Zero;
            _position = position;
            _r = r;
        }

        private void MakeMove(long time)
        // (0, 350), (0,350)
        //TODO zrobić rekord który będzie tworzony przy tym DataEventArgs a potem z niego brać pozycję
        //Przy pobieraniu pozycji ze wszystkich kul też najlepiej brać rekord a nie, osobno X oraz Y
        {
            Monitor.Enter(this.GetLockedObject());
            try
            {
                DataEventArgs args = new DataEventArgs(this.getPosition(), this.getSpeed(), this._r);
                ChangedPosition?.Invoke(this, args);
                _position += _speed * (time);
            }
            catch (SynchronizationLockException exception)
            {
                throw new Exception("Sync of monitor in Ball not working", exception);
            }
            finally
            {
                Monitor.Exit(_lockObject);
            }
        }

        private void StartMoving()
        {
            //Mniej wiecej tutaj stopwatch zrobic, i to odejmowac od siebie poprzednie
            //i zapamietywac a nie ze resetujemy clock
            //Concurent QUEUE albo coś takiego?
            //Cos o jakims typie lazy ???





            //Aby symulacja nie przebiegała zbyt szybko będziemy dzielić nasz czas przez 10
            //Oznacza to że nasza prędkość w kuli wyrażona jest w: długośćWData/10milisekund
            _stopwatch.Restart();
            _stopwatch.Start();
            long prevTime = _stopwatch.ElapsedMilliseconds / 10;

            while (IsMoving)
            {
                SpeedOfBall mySpeed = this.getSpeed();
                Thread.Sleep(calculateTimeToSleep());
                long time = _stopwatch.ElapsedMilliseconds / 10;
                MakeMove(time - prevTime);
                prevTime = time;
            }
        }

        private int calculateTimeToSleep()
        {
            double calc = 0;
            SpeedOfBall speed = this.getSpeed();
            calc = Math.Sqrt(Math.Pow(speed.X, 2) + Math.Pow(speed.Y, 2));

            calc = 5 / calc; //Ile zajmie przemieszczenie się przez 5 jednostek

            if (calc < 2)
            {
                return 2;
            }
            else return (int)calc;
        }

        public override object GetLockedObject()
        {
            return _lockObject;
        }
    }
}