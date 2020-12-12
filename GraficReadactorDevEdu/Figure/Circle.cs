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
        public List<Point> Points { get; set; }
        public Color color { get; set; }
        public int width { get; set; }
        public void Draw(Graphics graphics, Pen pen, Point[] pts)
        {
            graphics.DrawEllipse(pen,
                pts[0].X,
                pts[0].Y,
                pts[1].X - pts[0].X,
                 pts[1].X - pts[0].X);
        }
       
        public void Update(Point startPoint, Point endPoint)
        {
            Points = new List<Point>
            {
               startPoint,
               endPoint
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