﻿using Data;
using System.ComponentModel;
using System.Threading;
namespace Logic
{
    internal sealed class Logic : LogicAPI
    {
        static public readonly int frequency = 100; 
        private Board board;
        internal List<Ball> balls = new List<Ball>();
        public override List<BallAPI> createBalls(int maxX, int maxY, int amount)
        {
            List<BallAPI> balls = new List<BallAPI>(amount);
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i] = balls[i].createBall(maxX, maxY, 5);
            }
            return balls;
        }

        public void changeXdirection(BallAPI ball)
        {
            ball.setSpeed(-ball.getPosition().X, 0);
        }

        public void changeYdirection(BallAPI ball)
        {
            ball.setSpeed(0, ball.getSpeed().Y);
        }

        public override void updatePosition(BallAPI ball)
        {
            ball.setPosition(ball.getPosition().X + ball.getSpeed().X * (1.0f / frequency), 0.0f);
            ball.y += ball.getSpeed().Y * (1.0f / frequency);
            
        }

        public override void updateBoard(Board board)
        {
            for (int i = 0; i < board.GetBalls().Count; i++)
            {
                updatePosition(board.GetBalls()[i]);
            }
        }
    }
}