using PresentationModel;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PresentationViewModel
{
    public class IViewModel : INotifyPropertyChanged
    {
        protected ModelAbstractAPI modelAbstractAPI = ModelAbstractAPI.CreateNewModel(380, 380);
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
