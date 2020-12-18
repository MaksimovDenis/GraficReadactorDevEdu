using GraficReadactorDevEdu.Factor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
    class RTriangle : AFigure//Равнобедренный треугольник
    {
      

        public RTriangle(IFactory factorys)
        {
            factory = factorys;
        }

        public override void Draw(Graphics graphics, Pen pen, Point[] pts)
        {
            graphics.DrawPolygon(pen, pts);
        }

        public override void Update(Point startPoint, Point endPoint)
        {
            int tmp = endPoint.X - startPoint.X;
            Points = new List<Point>
            {
               startPoint,
               new Point (endPoint.X, endPoint.Y),
               new Point (startPoint.X-tmp, endPoint.Y),
            };
        }
        
    }
}

