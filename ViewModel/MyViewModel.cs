using PresentationViewModel;
using System.ComponentModel;

namespace ViewModel
{
    public class MyViewModel : INotifyPropertyChanged
    {

        private int numOfBalls;
        public event PropertyChangedEventHandler? PropertyChanged;

        public int HeightOfViewRectangle { get; set; }
        public int WidthOfViewRectangle { get; set; }

        public int AmountOfBalls
        {
            get => numOfBalls;
            set => numOfBalls = value;
        }

    }
}
