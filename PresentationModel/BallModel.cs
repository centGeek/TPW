using Logic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace PresentationModel
{
    internal class BallModel : BallModelAPI
    {
        private float x;
        private float y;
        private float r;

        LogicBallAPI logicBall;
        public BallModel(float x, float y, float r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }
        public BallModel(LogicBallAPI logicBallAPI)
        {
            logicBall = logicBallAPI;
        }


        public override float X
        {
            get { return logicBall.X; }
            set { Debug.WriteLine($"Było {x}, bedzie {value}"); logicBall.X = value; OnPropertyChanged(); }
        }
        public override float Y
        {
            get { return logicBall.Y; }
            set { logicBall.Y = value; OnPropertyChanged(); }
        }
        public override float R
        {
            get { return logicBall.R; }
            set { logicBall.R = value; OnPropertyChanged(); }
        }

        public override void UpdateBallModel(object s, LogicEventArgs e)
        {
            LogicBallAPI logicBallAPI = (LogicBallAPI)s;
            X = (float)logicBallAPI.X;
            Y = (float)logicBallAPI.Y;
            R = (float)logicBallAPI.R;
        }
    }
}
