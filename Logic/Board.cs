using System;
using System.Collections.Generic;
using System.Numerics;
using Data;
namespace Logic
{
    public class Board
    {
        private int _height { get; set; }
        private int _width { get; set; }
        private List<Ball> _balls { get; set; }

        public Board(int height, int width)
        {
            _height = height;
            _width = width;
            _balls = new List<Ball>();
        }

        public void FillBallList(int ballsQuantity, int ballRadius)
        {
            Random random = new R```andom();
            for (int i = 0; i < ballsQuantity; i++)
            {
                Vector2 vector = new Vector2(random.Next(ballRadius, _width - ballRadius), random.Next(ballRadius, _height - ballRadius));
                _balls.Add(new Ball(vector, ballRadius));
            }
        }

        public int GetHeight()
        {
            return _height;
        }

        public void SetHeight(int height)
        {
            _height = height;
        }

        public int GetWidth()
        {
            return _width;
        }

        public void SetWidth(int width)
        {
            _width = width;
        }
        public List<Ball> GetBalls()
        {
            return _balls;
        }
        public void checkBorderCollision()
        {
            LogicAPI logicAPI = new Logic(); 
            foreach (BallAPI ball in _balls)
            {
                if (ball.getPosition().X + ball.getR() >= this._width || ball.getPosition().X + ball.getSpeed().X + ball.getR() >= this._width || ball.getPosition().X + ball.getR() >= 0|| ball.getPosition().X + ball.getSpeed().X + ball.getR() >= 0)
                {
                    logicAPI.changeXdirection(ball); 
                    logicAPI.updatePosition(ball);
                }
                if (ball.getPosition().Y + ball.getR() >= this._height || ball.getPosition().Y + ball.getSpeed().Y + ball.getR() >= this.GetHeight() || ball.getPosition().Y + ball.getR() >= 0|| ball.getPosition().Y + ball.getSpeed().Y + ball.getR() >= 0)
                {
                    logicAPI.changeYdirection(ball);
                    logicAPI.updatePosition(ball);
                }
            }

        }
    }