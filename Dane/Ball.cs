using System.Diagnostics;
using System.Numerics;

namespace Data
{
    internal class Ball : BallAPI
    {
        private Vector2 _position { get; set; }
        private Vector2 _speed { get; set; }
        private int _r { get; }
        private int _m { get; }
        public override bool _isMoving { get; set; }

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
            _m = 5;
            _speed = speed;
            _position = position;
            _r = r;
            _stopwatch = new Stopwatch();
            Thread thread = new Thread(StartMoving);
            thread.Start();
            _isMoving = true;
        }
        public Ball(Vector2 position, int r)
        {
            _speed = Vector2.Zero;
            _position = position;
            _r = r;
        }

        private void MakeMove()
        // (0, 350), (0,350)
        //TODO zrobić rekord który będzie tworzony przy tym DataEventArgs a potem z niego brać pozycję
        //Przy pobieraniu pozycji ze wszystkich kul też najlepiej brać rekord a nie, osobno X oraz Y
        {
            Monitor.Enter(this.GetLockedObject());
            try
            {
                DataEventArgs args = new DataEventArgs(this);
                ChangedPosition?.Invoke(this, args);
                _position += _speed;
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

            while (_isMoving)
            {
                Thread.Sleep(10);
                MakeMove();
            }
        }



        public override object GetLockedObject()
        {
            return _lockObject;
        }
    }
}