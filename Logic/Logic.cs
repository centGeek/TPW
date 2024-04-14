using Data;
using System.ComponentModel;
using System.Numerics;
using System.Threading;
namespace Logic
{
    internal sealed class Logic : LogicAPI
    {
        static public readonly int frequency = 100; 
        private List<Ball> balls = new List<Ball>();
   
        public List<float> getAllXCoordinates()
        {
            List<float> xCoordinates= new List<float>();
            foreach (BallAPI ball in balls)
            {
                xCoordinates.Add(ball.getPosition().X);
            }
            return xCoordinates; 
        }
        public List<float> getAllYCoordinates()
        {
            List<float> yCoordinates = new List<float>();
            foreach (BallAPI ball in balls)
            {
                yCoordinates.Add(ball.getPosition().Y);
            }
            return yCoordinates;
        }
        public List<float> getAllRCoordinates()
        {
            List<float> radiusList = new List<float>();
            foreach (BallAPI ball in balls)
            {
                radiusList.Add(ball.getR());
            }
            return radiusList;
        }


        public override void changeXdirection(BallAPI ball)
        {
            ball.setSpeed(ball.getPosition().X, 0);
        }

        public override void changeYdirection(BallAPI ball)
        {
            ball.setSpeed(0, ball.getSpeed().Y);
        }

        public override void updatePosition(BallAPI ball)
        {
            ball.setPosition(ball.getPosition().X + ball.getSpeed().X * (1.0f / frequency),
                ball.getPosition().Y + ball.getSpeed().Y * (1.0f / frequency));
        }

        public override void updateBoard(BoardAPI board)
        {
            for (int i = 0; i < board.GetBalls().Count; i++)
            {
                updatePosition(board.GetBalls()[i]);
            }
        }
    }
}
