using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
    public class Square : IFigure
    {
        public List<Point> Points { get; set; }
        public Color color { get; set; }
        public int width { get; set; }
        public void Draw(Graphics graphics, Pen pen, Point[] pts)
        {
            graphics.DrawPolygon(pen,pts);
        }

        public void Update(Point startPoint, Point endPoint)
        {
            Points = new List<Point>
            {
               startPoint,
               new Point (endPoint.X, startPoint.Y),
              new Point (endPoint.X, endPoint.X+startPoint.Y-startPoint.X),
               new Point (startPoint.X,endPoint.X+startPoint.Y-startPoint.X)
            };
        }
        public bool Check()
        {
            if (Points == null)
            {
                return false;
            }
            return true;
        }
    }
}
