using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Data
{
    internal class Board : BoardAPI
    {
        public override int Width { get; }
        public override int Height { get; }

        private List<BallAPI> Balls = new List<BallAPI>();
        public Board(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override BallAPI AddBall(float X, float Y, int X_speed, int Y_speed, int radius)
        {
            BallAPI ball = BallAPI.CreateBall(X, Y, X_speed, Y_speed, radius);
            Balls.Add(ball);
            return ball;
        }

        public override List<BallAPI> GetAllBalls()
        {
            return Balls;
        }

        public override void RemoveAllBalls()
        {
            foreach (BallAPI ball in Balls)
            {
                ball.IsMoving = false;
            }
            Balls.Clear();
            Debug.WriteLine($"Według DataBoardAPI po usunieciu kuli jest {Balls.Count}");
        }
    }
}
