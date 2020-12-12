using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
    class Triangle : IFigure//Равнобедренный треугольник
    {
        public List<Point> Points { get; set; }
        public Color color { get; set; }
        public int width { get; set; }
        public void Draw(Graphics graphics, Pen pen, Point[] pts)
        {
            graphics.DrawPolygon(pen, pts);
        }

        public void Update(Point startPoint, Point endPoint)
        {
            int tmp = endPoint.X - startPoint.X;
            Points = new List<Point>
            {
               startPoint,
               new Point (endPoint.X, endPoint.Y),
               new Point (startPoint.X-tmp, endPoint.Y),
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

