using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationModel
{
    public class Model : ModelAbstractAPI
    {
        public Model()
        {

        }
        public Model(int w, int h) //Konstruktor
        {
            _height = h;
            _width = w;
            //TODO tu spodziewam się że logicAPI będzie miało funkcję CreateLogic albo coś podobnego
            //_logicAPI =                   
        }

        public override void StartSimulation()
        {
            int a = 1;
        }

        public override void StopSimulation()
        {
            throw new NotImplementedException();
        }
    }
}
