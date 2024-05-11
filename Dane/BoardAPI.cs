using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class BoardAPI
    {
        public abstract int Width { get; }
        public abstract int Height { get; }

        public abstract List<BallAPI> GetAllBalls();
        public abstract BallAPI AddBall(float X, float Y, int X_speed, int Y_speed, int radius);

        public abstract void RemoveAllBalls();
        public static BoardAPI CreateApi(int boardWidth, int boardHeight)
        {
            return new Board(boardWidth, boardHeight);
        }

    }
}
