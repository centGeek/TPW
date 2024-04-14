using Logic;
using System.Security.Cryptography.X509Certificates;

namespace PresentationModel
{
    internal class BallModel : BallModelAPI
    {
        private float x;
        private float y;
        private float r;


        public BallModel(float x, float y, float r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }


        public override float X
        {
            get { return x; }
            set { x = value; OnPropertyChanged(); }
        }
        public override float Y
        {
            get { return y; }
            set { y = value; OnPropertyChanged(); }
        }
        public override float R
        {
            get { return r; }
            set { r = value; OnPropertyChanged(); }
        }

        public override void UpdateBallModel(object s, LogicEventArgs e)
        {
            LogicBallAPI logicBallAPI = (LogicBallAPI)s;
            x = (float)logicBallAPI.X;
            y = (float)logicBallAPI.Y;
            r = (float)logicBallAPI.R;
        }
    }
}
