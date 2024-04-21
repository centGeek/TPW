using System.Diagnostics;
using System.Numerics;

namespace Data
{
    internal class Ball : BallAPI
    {
        private Vector2 _position { get; set; }
        private Vector2 _speed { get; set; }
        private int _r { get; set; }

        private int _maxX = 370;
        private int _maxY = 370;

        public override Vector2 getPosition()
        {
            return _position;
        }
        public override void setPosition(float x, float y)
        {
            _position = new Vector2(x, y);
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
            _speed = speed;
            _position = position;
            _r = r;
        }
        public Ball(Vector2 position, int r)
        {
            _speed = Vector2.Zero;
            _position = position;
            _r = r;
        }

        public override void MakeMove(int width, int height)
        // (0, 350), (0,350)

        {
            bool isCorrectInX = (this.getPosition().X + this.getR() + this.getSpeed().X < _maxX /*- 2 * getR()*/) && (this.getPosition().X + this.getSpeed().X /*- this.getR()*/ > 0);
            bool isCorrectInY = (this.getPosition().Y + this.getR() + this.getSpeed().Y < _maxY /*- 2 * getR()*/) && (this.getPosition().Y + this.getSpeed().Y /*- this.getR()*/ > 0);
            if (!isCorrectInX)
            {
                this.setSpeed(-this.getSpeed().X, this.getSpeed().Y);

            }
            if (!isCorrectInY)
            {
                this.setSpeed(this.getSpeed().X, -this.getSpeed().Y);

            }

            _position += _speed;
            DataEventArgs args = new DataEventArgs(this);
            ChangedPosition?.Invoke(this, args);

        }

    }
}
