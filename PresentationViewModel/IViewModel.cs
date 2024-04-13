using PresentationModel;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PresentationViewModel
{
    public class IViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
