﻿using GraficReadactorDevEdu.Figure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Factor
{
    public class BrokenLinesFactory  : IFactory
    {
        public IFigure CreateFigure()
        {
            return new BrokenLines();
        }
    }
}
