using GraficReadactorDevEdu.Figure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.IFactory
{
    public interface IFactory
    {
        IFigure CreateFigure();
    }
}
