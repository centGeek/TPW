using PresentationViewModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Windows.Input;

namespace PresentationViewModel
{
    public class MyViewModel : IViewModel
    {


        public int HeightOfViewRectangle
        {
            get
            {
                return modelAbstractAPI._height;
            }
            set
            {
                modelAbstractAPI._height = value;
                OnPropertyChanged();
            }
        }
        public int WidthOfViewRectangle
        {
            get
            {
                return modelAbstractAPI._width;
            }
            set
            {
                modelAbstractAPI._width = value;
                OnPropertyChanged();
            }
        }

        public int NumOfBalls
        {
            get
            {
                return modelAbstractAPI._numOfBalls;
            }
            set
            {
                if (value >= 0)
                {
                    modelAbstractAPI._numOfBalls = value;
                    OnPropertyChanged();
                }
                else
                {
                    modelAbstractAPI._numOfBalls = 0;
                    OnPropertyChanged();
                }
            }
        }

        private void addOneToNumOfBalls()
        {
            NumOfBalls++;
        }
        private void subtractOneToNumOfBalls()
        {
            NumOfBalls--;
        }

        private void StartTheSimulation()
        {
            modelAbstractAPI.StartSimulation();
        }
        private void StopTheSimulation()
        {
            modelAbstractAPI.StopSimulation();
        }

        public ICommand CommandAddOneToNumOfBalls { get; private set; }
        public ICommand CommandSubtractOneToNumOfBalls { get; private set; }
        public ICommand CommandStartTheSimulation { get; private set; }
        public ICommand CommandStopTheSimulation { get; private set; }



        public MyViewModel()
        {
            modelAbstractAPI._numOfBalls = 15;
            CommandAddOneToNumOfBalls = new RelayCommand(addOneToNumOfBalls);
            CommandSubtractOneToNumOfBalls = new RelayCommand(subtractOneToNumOfBalls);
            CommandStartTheSimulation = new RelayCommand(StartTheSimulation);
            CommandStopTheSimulation = new RelayCommand(StopTheSimulation);
        }

    }
}
