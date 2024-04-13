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
        public abstract void setPosition(float x, float y);
        public abstract void setSpeed(float x, float y);
        public abstract Vector2 getSpeed();
        public abstract int getR();


        public event PropertyChangedEventHandler? PropertyChanged;

        public abstract BallAPI createBall(float X, float Y, int radius);

        public void RaisePropertyChanged(string v)
        {
            throw new NotImplementedException();
        }
    }


}
