using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace LogicTest
{
    [TestClass]
    public class LogicBoardTest
    {
        [TestClass]
        internal class DataBoardForTest : BoardAPI
        {
            public override int Width { get; set; }
            public override int Height { get; set; }

            private List<BallAPI> Balls = new List<BallAPI>();
            public DataBoardForTest(int width, int height)
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


        }



        [TestMethod]
        public void addingAndGettingBallsTest()
        {
            LogicBoardAPI logicBoard = LogicBoardAPI.CreateAPI(new DataBoardForTest(370, 370));
            logicBoard.addBalls(3, 5);
            Assert.AreEqual(3, logicBoard.getBalls().Count);
        }
        [TestMethod]
        public void ballsPositionsAndRadiusTest()
        {
            LogicBoardAPI logicBoard = LogicBoardAPI.CreateAPI(new DataBoardForTest(370, 370));
            logicBoard.addBalls(1000, 5);
            List<LogicBallAPI> balls = logicBoard.getBalls();
            for (int i = 0; i < balls.Count - 1; i++)
            {
                Assert.AreEqual(5, balls[i].R);
                List<float> positionsFirst = new List<float>();
                positionsFirst.Add(balls[i].X);
                positionsFirst.Add(balls[i].Y);
                List<float> positionsSecond = new List<float>();
                positionsSecond.Add(balls[i + 1].X);
                positionsSecond.Add(balls[i + 1].Y);
                Assert.AreNotEqual(positionsFirst, positionsSecond);
            }
        }

    }
}
