using GraficReadactorDevEdu.Factor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
    public class Ellipse : AFigure
    {
        public Ellipse(IFactory factorys) 
        {
            factory = factorys;
        }
        public override void Draw(Graphics graphics, Pen pen, Point[] pts)
        {
            graphics.DrawEllipse(pen,
                pts[0].X,
                pts[0].Y,
                pts[1].X - pts[0].X,
                pts[1].Y - pts[0].Y);
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
