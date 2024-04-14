using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic;


namespace LogicTest
{
    [TestClass]
    public class LogicBoardTest
    {
        [TestMethod]
        public void addingAndGettingBallsTest()
        {
            LogicBoardAPI logicBoard = LogicBoardAPI.CreateAPI();
            logicBoard.addBalls(3, 5);
            Assert.AreEqual(3, logicBoard.getBalls().Count);
        }
        [TestMethod]
        public void ballsPositionsAndRadiusTest()
        {
            LogicBoardAPI logicBoard = LogicBoardAPI.CreateAPI();
            logicBoard.addBalls(1000, 5);
            List<LogicBallAPI> balls = logicBoard.getBalls();
            for (int i = 0; i < balls.Count -1 ; i++)
            {
                Assert.AreEqual(5, balls[i].R);
                List<float> positionsFirst = new List<float>();
                positionsFirst.Add(balls[i].X);
                positionsFirst.Add(balls[i].Y);
                List<float> positionsSecond = new List<float>();
                positionsSecond.Add(balls[i+1].X);
                positionsSecond.Add(balls[i+1].Y);
                Assert.AreNotEqual(positionsFirst, positionsSecond);
            }
        }

    }
}
