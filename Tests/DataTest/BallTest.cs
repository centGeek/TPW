using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics; 
using System.Text;
using System.Threading.Tasks;

namespace DataTest
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void GetterSetterConstuctorTest()
        {
            Ball ball = new Ball(new Vector2(3, 5), 3);
            Assert.AreEqual(new Vector2(3, 5), ball.getPosition());
            Assert.AreEqual(3, ball.getR());

            ball.setSpeed(3, 2);
            ball.setPosition(5, 10);

            Assert.AreEqual(new Vector2(5, 10), ball.getPosition());
            Assert.AreEqual(new Vector2(3, 2), ball.getSpeed());
        }
        [TestMethod]
        public void creatingBallTest()
        {
            BallAPI ball = BallAPI.CreateBall(3, 5, 10, 11, 6);
            Assert.AreEqual(3, ball.getPosition().X);
            Assert.AreEqual(5, ball.getPosition().Y);
            Assert.AreEqual(11, ball.getSpeed().Y);
            Assert.AreEqual(10, ball.getSpeed().X);
            Assert.AreEqual(6, ball.getR());


        }
    }
}
