using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class DataEventArgs : DataEventArgsAPI
    {

        public DataEventArgs(PositionOfBall position, SpeedOfBall speed, int rad)
        {
            //Odziedziczone z API
            positionOfBall = position;
            speedOfBall = speed;
            radius = rad;
        }
    }

}