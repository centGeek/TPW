using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Board
    {
        private int height { get;  } 
        private int width { get; }

        private List<Ball> balls = new List<Ball>();

        public List<Ball> Balls
        {
            get { return balls; }
        }

        public Board(int height, int width) 
        {
            this.height = height;
            this.width = width;
        }

        public void fillBallList(int ballsQuantity, int ballRadius)
        {
            Random random = new Random();
            for(int i=0; i < ballsQuantity; i++)
            {
                Vector2 vector = new Vector2(random.Next(ballRadius, this.width - ballRadius), random.Next(ballRadius, this.height - ballRadius));
                balls.Add(new Ball(vector, ballRadius)); 

            }
        }
    }
}
