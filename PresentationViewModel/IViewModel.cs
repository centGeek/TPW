using PresentationModel;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PresentationViewModel
{
    public abstract class IViewModel : INotifyPropertyChanged
    {
        protected ObservableCollection<BallModelAPI> _ballsFromModel;
        protected ModelAbstractAPI _modelAbstractAPI = ModelAbstractAPI.CreateNewModel(380, 380);
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
