using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataEventArgsAPI : EventArgs
    {
        public static DataEventArgsAPI CreateDataEventArgs(BallAPI ball)
        {
            return new DataEventArgs(ball);
        }
    }
}
