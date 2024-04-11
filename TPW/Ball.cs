using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Logic
{
    public class Ball : INotifyPropertyChanged
    {
        private Vector2 position { get; set;  }
        private Vector2 speed { get; set; }

        private int r;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Ball(Vector2 position, int r)
        {
            this.position = position;
            this.speed = new Vector2(0,0);
            this.r = r;
        }
        public void MakeMove()
        {
            position += speed; 
        }
        public event ProgressChangedEventHandler propertyChanged;
        
        protected void OnPropertyChanged( [CallerMemberName] string propertyName = "") 
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));        }
            }
    }
