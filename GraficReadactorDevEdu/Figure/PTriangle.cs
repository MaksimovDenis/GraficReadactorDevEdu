using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
    class PTriangle : IFigure//Прямоугольный треугольник
    {
        public Point[] GetPoints(Point startPoint, Point endPoint)
        {
           
            return new Point[]
            {
               startPoint,
               new Point (endPoint.X, endPoint.Y),
               new Point (startPoint.X, endPoint.Y),
            };
        }
    }
}
