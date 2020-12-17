using GraficReadactorDevEdu.Factor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
    class RectangleFigure : AFigure
    {

        public RectangleFigure(IFactory factorys)
        {
            factory = factorys;
        }

        public override void Draw(Graphics graphics, Pen pen, Point[] pts)
        {
            graphics.DrawPolygon(pen, pts);
        }

        public override void Update(Point startPoint, Point endPoint)
        {
            Points = new List<Point> 
            {
               startPoint,
               new Point (startPoint.X, endPoint.Y),
               endPoint,
               new Point (endPoint.X,startPoint.Y)
            };
        }


       
    }
}
