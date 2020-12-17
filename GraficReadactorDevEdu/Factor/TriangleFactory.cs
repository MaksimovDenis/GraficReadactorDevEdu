using GraficReadactorDevEdu.Figure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Factor
{
    public class TriangleFactory: IFactory
    {
        public AFigure CreateFigure(IFactory factory)
        {
            return new Triangle(factory);
        }
    }
}
