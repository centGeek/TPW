using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PresentationModel
{
    public class Model : ModelAbstractAPI
    {
        public Model(int w, int h)
        {
            _height = h;
            _width = w;
            _logicAPI = LogicBoardAPI.CreateAPI();
            _ballsModel = new List<BallModelAPI>();
        }

        public override List<BallModelAPI> GetBallsModel()
        {
            //_ballsModel.Clear();    //Na wszelki wypadke
            //foreach (LogicBallAPI logicBall in _logicAPI.getBalls())
            //{
            //    BallModelAPI ballModel = BallModelAPI.CreateBallModel(logicBall.X, logicBall.Y, logicBall.R);
            //    _ballsModel.Add(ballModel);
            //    logicBall.changedPosition += ballModel.UpdateBallModel!;
            //}
            //return _ballsModel;

            return _ballsModel;
        }

        public override void StartSimulation()
        {
            _logicAPI.addBalls(_numOfBalls, 20);
            foreach (LogicBallAPI logicBall in _logicAPI.getBalls())
            {
                BallModelAPI ballModelAPI = BallModelAPI.CreateBallModel(logicBall);
                logicBall.changedPosition += ballModelAPI.UpdateBallModel;
                _ballsModel.Add(ballModelAPI);
            }
            _logicAPI.startMoving();


        }

        public override void StopSimulation()
        {

            _logicAPI.removeBalls();
            _ballsModel.Clear();

        }



    }
}




//TO SIE MOZE JESZCZE PRZYDA
//Debug.WriteLine($"MODEL stowrzyłem kulke w ilosc {_ballsModel.Count}");

/* Task.Run(() =>
 {
     while (true)
     {
         //NumOfBalls = r.Next().ToString();
         Debug.WriteLine($"Kule w model : {_ballsModel.Count}");
         //Debug.WriteLine($"pierwsza kula ma takie  : x{_ballsModel[0].X}");
         //_ballsModel[0].X -= 10;

         Thread.Sleep(1000);
     }
 });*/