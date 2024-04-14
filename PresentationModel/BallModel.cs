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


        public BallModel(float x, float y, float r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }


        public override float X
        {
            get { return x; }
            set { Debug.WriteLine($"Było {x}, bedzie {value}"); x = value; OnPropertyChanged("BallsFromModel"); }
        }
        public override float Y
        {
            get { return y; }
            set { y = value; OnPropertyChanged(nameof(Y)); }
        }
        public override float R
        {
            get { return r; }
            set { r = value; OnPropertyChanged(); }
        }

        public override void UpdateBallModel(object s, LogicEventArgs e)
        {
            LogicBallAPI logicBallAPI = (LogicBallAPI)s;
            X = (float)logicBallAPI.X;
            Y = (float)logicBallAPI.Y;
            //r = (float)logicBallAPI.R;
        }
    }
}
