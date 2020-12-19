using GraficReadactorDevEdu.Figure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Factor
{
    public class FreeTriangleFactory : IFactory
    {
        public AFigure CreateFigure()
        {
            return new FreeTriangle(this);
        }
    }
}