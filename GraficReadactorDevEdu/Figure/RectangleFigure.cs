using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
    class RectangleFigure : IFigure
    {
        public Point[] GetPoints(Point startPoint, Point endPoint)
        {
            return new Point[]
            {
               startPoint,
               new Point (startPoint.X, endPoint.Y),
               endPoint,
               new Point (endPoint.X,startPoint.Y)
            };
        }
    }
}
