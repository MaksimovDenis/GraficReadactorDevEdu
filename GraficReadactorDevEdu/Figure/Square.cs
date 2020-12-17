using GraficReadactorDevEdu.Factor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
    public class Square : AFigure
    {
        public Square(IFactory factorys)
        {
            factory = factorys;
        }

        public override void Draw(Graphics graphics, Pen pen, Point[] pts)
        {
            graphics.DrawPolygon(pen,pts);
        }

        public override void Update(Point startPoint, Point endPoint)
        {
            Points = new List<Point>
            {
               startPoint,
               new Point (endPoint.X, startPoint.Y),
              new Point (endPoint.X, endPoint.X+startPoint.Y-startPoint.X),
               new Point (startPoint.X,endPoint.X+startPoint.Y-startPoint.X)
            };
        }
        
    }
}
