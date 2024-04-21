using Logic;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PresentationModel
{
    public abstract class ModelAbstractAPI : INotifyPropertyChanged
    {
        public int _numOfBalls;
        public int _height;
        public int _width;
        protected LogicBoardAPI _logicAPI;
        public abstract void StartSimulation();
        public abstract void StopSimulation();

        public static ModelAbstractAPI CreateNewModel(int w, int h)
        {
            return new Model(w, h);
        }
        protected List<BallModelAPI> _ballsModel;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public abstract List<BallModelAPI> GetBallsModel();
    }
}
