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
        public Model(int w, int h) //Konstruktor
        {
            _height = h;
            _width = w;
            _logicAPI = LogicBoardAPI.CreateAPI();
        }

        public override ObservableCollection<BallModelAPI> GetBallsModel()
        {
            _ballsModel.Clear();    //Na wszelki wypadke
            foreach (LogicBallAPI logicBall in _logicAPI.getBalls())
            {
                BallModelAPI ballModel = BallModelAPI.CreateBallModel(logicBall.X, logicBall.Y, logicBall.R);
                _ballsModel.Add(ballModel);
                logicBall.changedPosition += ballModel.UpdateBallModel!;
            }
            return _ballsModel;
        }

        public override void StartSimulation()
        {
            //TODO tu sie jazda troche dzieje
            Debug.WriteLine($"Model chce pojawić kule w ilosci {_numOfBalls}");
            _logicAPI.addBalls(_numOfBalls, 10);

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
        }

        public override void StopSimulation()
        {
            //TODO usunąć DEBUG
            _logicAPI.removeBalls();
            Debug.WriteLine($"Usuwam {_ballsModel.Count} kulek");
            _ballsModel.Clear();
            Debug.WriteLine($"pozostało: {_ballsModel.Count}");
        }



    }
}
