using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu.Factories
{
    public class RectangleFactrory
    {
        public IFigure CreateFigure()
        {
            return new RectangleFigure();
        }
    }
}
