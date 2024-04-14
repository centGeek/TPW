﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace Data
{
    public class Board : BoardAPI
    {
        public override int Width { get; set; }
        public override int Height { get; set; }

        private List<BallAPI> Balls = new List<BallAPI>();
        public Board(int width, int height)
        {
            Width = width;
            Height = height;;
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


    }
}