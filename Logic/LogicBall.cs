using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logic
{
    internal class LogicBall : LogicBallAPI
    {
        private float _x;
        private float _y;
        private float _r;

        public override event EventHandler<LogicEventArgsAPI>? changedPosition;

        internal void UpdateBall(Object s, DataEventArgsAPI e)
        {
            BallAPI ball = (BallAPI)s;
            _x = e.positionOfBall.X;
            _y = e.positionOfBall.Y;
            _r = e.radius;
            LogicEventArgsAPI args = LogicEventArgs.CreateLogicEventArgs(_x, _y, _r);
            changedPosition?.Invoke(this, args);
        }
        public LogicBall(float x, float y, float r)
        {
            this._x = x;
            this._y = y;
            this._r = r;
        }
        public override float X
        {
            get => _x;
            set { _x = value; }
        }
        public override float Y
        {
            get => _y;
            set { _y = value; }
        }
        public override float R
        {
            get => _r;
            set { _r = value; }
        }

    }
}
