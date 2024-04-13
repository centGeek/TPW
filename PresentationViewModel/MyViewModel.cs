using PresentationViewModel;
using System.ComponentModel;
using System.Diagnostics;

namespace PresentationViewModel
{
    public class MyViewModel : IViewModel
    {

        private string _numOfBalls;

        public int HeightOfViewRectangle { get; set; }
        public int WidthOfViewRectangle { get; set; }

        public string NumOfBalls
        {
            get
            {
                return _numOfBalls;
            }
            set
            {
                _numOfBalls = value;
                OnPropertyChanged();
            }
        }

        public MyViewModel()
        {
            _numOfBalls = "15";
            Task.Run(() =>
            {
                Random r = new Random();
                while (true)
                {

                    //NumOfBalls = r.Next().ToString();
                    Debug.WriteLine($"Num : {NumOfBalls},  {_numOfBalls}");
                    Thread.Sleep(1000);
                }
            });


        }

    }
}
