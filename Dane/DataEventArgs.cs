using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataEventArgs
    {
        public BallAPI Ball;
        public DataEventArgs(BallAPI ball)
        {
            Ball = ball;
        }
    }

}