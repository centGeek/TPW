using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicBoardAPI
    {
        public abstract void addBalls(int ballsQuantity, int ballRadius);
        public abstract List<LogicBallAPI> getBalls();
        public static LogicBoardAPI CreateAPI(BoardAPI dataApi = null)
        {
            return new LogicBoard(dataApi == null ? BoardAPI.CreateApi(370, 370) : dataApi);
        }
        public abstract void checkBorderCollision(Object s, DataEventArgs e);

        public abstract void removeBalls();

        public abstract void startMoving();

        protected bool isMoving;
    }
}
