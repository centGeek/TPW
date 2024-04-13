using Data;
using System.Numerics;
namespace Logic
{
    public abstract class LogicAPI
    {
        public abstract void updatePosition(BallAPI ball);
        public abstract void updateBoard(BoardAPI board);
        public abstract List<BallAPI> createBalls(int maxX, int maxY, int amount);
        public abstract void changeYdirection(BallAPI ball);
        public abstract void changeXdirection(BallAPI ball);

    }
}
