using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class BallAPI : INotifyPropertyChanged
    {
        public abstract Vector2 getPosition();
        public abstract void setPosition(Vector2 value);
        public abstract void setSpeed(Vector2 value);
        public abstract Vector2 getSpeed();
        public abstract int getR();

        public event PropertyChangedEventHandler? PropertyChanged;

        public BallAPI createBall(int id, float X, float Y, int radius)
        {
            return new Ball(new Vector2(X, Y), radius); 
        }
    }


}
