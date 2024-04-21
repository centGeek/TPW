using Data;
using Logic;
using System.Numerics;
namespace DataTest
{
    [TestClass]
    public class BoardTest
    {

        [TestClass]
        internal class DataBallForTest : BallAPI
        {
            public override event EventHandler<DataEventArgsAPI> ChangedPosition;

            private Vector2 _position { get; set; }
            private Vector2 _speed { get; set; }
            private int _r { get; set; }

            private int _maxX = 370;
            private int _maxY = 370;

            public override Vector2 getPosition()
            {
                return _position;
            }
            public override int getR()
            {
                return _r;
            }
            public override Vector2 getSpeed()
            {
                return _speed;
            }
            public override void MakeMove(int width, int height)
            {
                _position = _position + _speed;
            }
            public override void setPosition(float x, float y)
            {
                _position = new Vector2(x, y);
            }

            public override void setSpeed(float x, float y)
            {
                _speed = new Vector2(x, y);
            }
            public DataBallForTest()
            {

            }
        }
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
        public void GetterSetterConstuctorTest()
        {
            LogicBoardAPI board = LogicBoardAPI.CreateAPI(new DataBoardForTest(3, 5));
            Assert.AreEqual(5, board.GetHeight());
            Assert.AreEqual(3, board.GetWidth());

            board.SetHeight(5);
            board.SetWidth(8);

            Assert.AreEqual(5, board.GetHeight());
            Assert.AreEqual(8, board.GetWidth());
        }
    }
}