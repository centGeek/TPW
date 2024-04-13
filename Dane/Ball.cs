using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Data
{
    public class Ball : BallAPI
    {
        private Vector2 _position {  get; set; }
        private Vector2 _speed { get; set; }
        private int _r { get;  }

        public override Vector2 getPosition()
        {
             return _position;
        }
        public override void setPosition(float x, float y)
        {
            _position= new Vector2(x, y);
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
        public event PropertyChangedEventHandler PropertyChanged;

        public Ball(Vector2 position, int r)
        {
            _position = position;
            _speed = new Vector2(0, 0);
            _r = r;
        }

        public void MakeMove()
        {
            _position += _speed;
            OnPropertyChanged(nameof(_position));
        }
        public override BallAPI createBall(float X, float Y, int radius)
        {
            return new Ball(new Vector2(X, Y), radius); 
        }


        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
