using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class DataEventArgs : DataEventArgsAPI
    {
        public BallAPI Ball;
        public DataEventArgs(BallAPI ball)
        {
            Ball = ball;
        }
    }

}