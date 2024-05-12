using System.Diagnostics;
using System.Numerics;

namespace Data
{
    internal class Ball : BallAPI
    {
        private Vector2 _position { get; set; }
        private Vector2 _speed { get; set; }
        private int _r { get; set; }
        private int _m { get; }
        public override bool _isMoving { get; set; }

        public override int Mass { get { return _m; } }

        private static object _lockObject = new object();

        public override Vector2 getPosition()
        {
            return _position;
        }

        public override Vector2 getSpeed()
        {
            return _speed;
        }

        public override void setSpeed(float x, float y)
        {
            _speed = new Vector2(x, y);
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
        {
            Monitor.Enter(_lockObject);
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