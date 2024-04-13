using System;
using System.Collections.Generic;
using System.Numerics;

namespace Data
{
    public class Board
    {
        private int _height { get; set; }
        private int _width { get; set;  }
        private List<Ball> _balls { get; set; }

        public Board(int height, int width)
        {
            _height = height;
            _width = width;
            _balls = new List<Ball>();
        }

        public void FillBallList(int ballsQuantity, int ballRadius)
        {
            Random random = new Random();
            for (int i = 0; i < ballsQuantity; i++)
            {
                Vector2 vector = new Vector2(random.Next(ballRadius, _width - ballRadius), random.Next(ballRadius, _height - ballRadius));
                _balls.Add(new Ball(vector, ballRadius));
            }
        }

        // Getter i setter dla Height
        public int GetHeight()
        {
            return _height;
        }

        public void SetHeight(int height)
        {
            _height = height;
        }

        // Getter i setter dla Width
        public int GetWidth()
        {
            return _width;
        }

        public void SetWidth(int width)
        {
            _width = width;
        }

        // Getter dla Balls
        public List<Ball> GetBalls()
        {
            return _balls;
        }
    }
}