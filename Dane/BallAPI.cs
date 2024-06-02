using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class BallAPI
    {
        public abstract PositionOfBall getPosition();
        public abstract void setSpeed(float x, float y);
        public abstract SpeedOfBall getSpeed();
        public abstract int getR();
        public abstract bool IsMoving { get; set; }

        public abstract int Mass { get; }

        public abstract object GetLockedObject();

        public abstract event EventHandler<DataEventArgsAPI> ChangedPosition;

        public static BallAPI CreateBall(float X, float Y, float X_speed, float Y_speed, int radius)
        {
            return new Ball(new Vector2(X, Y), radius, new Vector2(X_speed, Y_speed));
        }
        public void RaisePropertyChanged(string v)
        {
            throw new NotImplementedException();
        }
    }
    public record PositionOfBall(float X, float Y);

    public record SpeedOfBall(float X, float Y);


}
