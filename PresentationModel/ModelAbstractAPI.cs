﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationModel
{
    public class ModelAbstractAPI : INotifyPropertyChanged
    {
        public ModelAbstractAPI() { }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}