using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
    public class Circle : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Point[] pts)
        {
            graphics.DrawEllipse(pen,
                pts[0].X,
                pts[0].Y,
                pts[1].X - pts[0].X,
                 pts[1].X - pts[0].X);
        }
       
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