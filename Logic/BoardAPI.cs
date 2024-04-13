using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class BoardAPI
    {
        public abstract void FillBallList(int ballsQuantity, int ballRadius);
        public abstract List<Ball> GetBalls();


    }
}
