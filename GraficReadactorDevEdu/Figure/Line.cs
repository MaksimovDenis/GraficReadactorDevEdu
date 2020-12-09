using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
    public class Line : IFigure
    {
        public void Draw(Graphics graphics, Pen pen, Point[] pts)
        {
            graphics.DrawLine(pen, pts[0], pts[1]);
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
