using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
   public class BrokenLines : IFigure
    {

        public Point[] GetPoints(Point startPoint, Point endPoint)
        {
           
            return new Point[]
            {
               startPoint,
               endPoint

            };
        }
    }
}
