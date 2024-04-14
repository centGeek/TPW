using Logic;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationModel
{
    public abstract class ModelAbstractAPI
    {
        public int _numOfBalls;
        public int _height;
        public int _width;
        protected LogicAPI _logicAPI;
        public abstract void StartSimulation();
        public abstract void StopSimulation();

        public static Model CreateNewModel(int w, int h)
        {
            return new Model(w, h);
        }
    }
}
