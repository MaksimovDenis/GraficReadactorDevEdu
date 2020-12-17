using GraficReadactorDevEdu.Factor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
    public class BrokenLines : AFigure
    {

        public BrokenLines(IFactory factorys)
        {
            factory = factorys;
        }

        public Point tmpPoint;
        public override void Draw(Graphics graphics, Pen pen, Point[] pts)
        {
            graphics.DrawLine(pen, pts[0], pts[1]);
            
        }

        public override void Update(Point startPoint, Point endPoint)
        {

            Points = new List<Point>
            {
               startPoint,
               endPoint

            };
        }
       
    }
}
