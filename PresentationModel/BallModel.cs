using Logic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace PresentationModel
{
    internal class BallModel : BallModelAPI
    {
        private float _x;
        private float _y;
        private float _r;
        private float _scale;

        LogicBallAPI logicBall;
        public BallModel(float x, float y, float r)
        {
            this._x = x;
            this._y = y;
            this._r = r;
        }
        public BallModel(LogicBallAPI logicBallAPI, float scale)
        {
            this._scale = scale;
            logicBall = logicBallAPI;
        }


        public override float X
        {
            get { return logicBall.X; }
            set { OnPropertyChanged(); }
        }
        public override float Y
        {
            get { return logicBall.Y; }
            set { OnPropertyChanged(); }
        }
        public override float C
        {
            get { return 2 * logicBall.R; }
            set { OnPropertyChanged(); }
        }

        public override float Scale
        {
            get { return _scale; }
        }

        public override void UpdateBallModel(object s, LogicEventArgsAPI e)
        {
            X = e.x * _scale;
            Y = e.y * _scale;
            C = e.r * _scale;
        }
    }
}
