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
        public override void setPosition(Vector2 position)
        {
            _position= position;
        }
        public override Vector2 getSpeed()
        {
            return _speed; 
        }

        public override void setSpeed(Vector2 position)
        {
            _speed = position; 
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
            PropertyChanged += (sender, args) => { };
        }

        public void MakeMove()
        {
            _position += _speed;
            OnPropertyChanged(nameof(_position));
        }


        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
