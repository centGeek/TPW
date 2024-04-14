using Data;
using System;
using System.Collections.Generic;
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
            return new LogicBoard(dataApi == null ? BoardAPI.CreateApi(380, 380) : dataApi);
        }
        public abstract void removeBalls();
    }
}
