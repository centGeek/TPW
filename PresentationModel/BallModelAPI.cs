using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PresentationModel
{
    public abstract class BallModelAPI : INotifyPropertyChanged
    {
        public static BallModelAPI CreateBallModel(float x, float y, float r)
        {
            return new BallModel(x, y, r);
        }
        public static BallModelAPI CreateBallModel(LogicBallAPI logicBallAPI, float scale)
        {
            return new BallModel(logicBallAPI, scale);
        }

        public abstract float Scale { get; }
        public abstract float X { get; set; }
        public abstract float Y { get; set; }
        public abstract float C { get; set; }



        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public abstract void UpdateBallModel(Object s, LogicEventArgsAPI e);
    }
}
