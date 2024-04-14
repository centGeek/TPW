using PresentationModel;
using PresentationViewModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Windows.Input;

namespace PresentationViewModel
{
    public class MyViewModel : IViewModel
    {

        // TODO mam takie marzenie aby czytać z ekrany wysokość tego co się dopasuje do warunków a następnie 
        // to będzie przekazywane niżej
        public int HeightOfViewRectangle
        {
            get
            {
                return _modelAbstractAPI._height;
            }
            set
            {
                _modelAbstractAPI._height = value;
                OnPropertyChanged();
            }
        }
        public int WidthOfViewRectangle
        {
            get
            {
                return _modelAbstractAPI._width;
            }
            set
            {
                _modelAbstractAPI._width = value;
                OnPropertyChanged();
            }
        }

        public int NumOfBalls
        {
            get
            {
                return _modelAbstractAPI._numOfBalls;
            }
            set
            {
                if (value >= 0)
                {
                    _modelAbstractAPI._numOfBalls = value;
                    OnPropertyChanged();
                }
                else
                {
                    _modelAbstractAPI._numOfBalls = 0;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<BallModelAPI> BallsFromModel => _modelAbstractAPI.GetBallsModel();


        private void AddOneToNumOfBalls()
        {
            NumOfBalls++;
        }
        private void SubtractOneToNumOfBalls()
        {
            NumOfBalls--;
        }

        private void StartTheSimulation()
        {
            _modelAbstractAPI.StartSimulation();
            OnPropertyChanged(nameof(BallsFromModel));
        }
        private void StopTheSimulation()
        {
            _modelAbstractAPI.StopSimulation();
            OnPropertyChanged(nameof(BallsFromModel));

        }

        public ICommand CommandAddOneToNumOfBalls { get; private set; }
        public ICommand CommandSubtractOneToNumOfBalls { get; private set; }
        public ICommand CommandStartTheSimulation { get; private set; }
        public ICommand CommandStopTheSimulation { get; private set; }



        public MyViewModel()
        {
            _modelAbstractAPI = ModelAbstractAPI.CreateNewModel(380, 380);
            _modelAbstractAPI._numOfBalls = 15;
            CommandAddOneToNumOfBalls = new RelayCommand(AddOneToNumOfBalls);
            CommandSubtractOneToNumOfBalls = new RelayCommand(SubtractOneToNumOfBalls);
            CommandStartTheSimulation = new RelayCommand(StartTheSimulation);
            CommandStopTheSimulation = new RelayCommand(StopTheSimulation);
            Task.Run(() =>
            {
                Random r = new Random();
                while (true)
                {
                    Debug.WriteLine($"Num : {NumOfBalls},  {_modelAbstractAPI._numOfBalls}");
                    Thread.Sleep(1000);
                }
            });
        }

    }
}
