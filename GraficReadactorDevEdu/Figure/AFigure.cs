using GraficReadactorDevEdu.Factor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GraficReadactorDevEdu.Figure
{
    public abstract class AFigure
    {
        public List<Point> Points { get; set; }
        public Color color { get; set; }
        public int width { get; set; }
        protected IFactory factory;
        public  int N=3;

        public abstract void Draw(Graphics graphics, Pen pen, Point[] pts);
        public abstract void Update(Point startPoint, Point endPoint);
        public void UpN(int quantity)
        {
            N = quantity;
        }
        public bool Check()
        {
            if (Points == null)
            {
                return false;
            }
            return true;
        }
        private bool Contain(Point start, Point end, Point checkPoint, double accuracy)
        {
            double x1 = start.X;
            double y1 = start.Y;
            double x2 = end.X;
            double y2 = end.Y;
            double x = checkPoint.X;
            double y = checkPoint.Y;

            if (CheckInside(x, x1, x2, accuracy) && CheckInside(y, y1, y2, accuracy))
                return Math.Abs((x - x1) * (y2 - y1) - (y - y1) * (x2 - x1)) < accuracy / 2 * Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            else return false;
        }

        private bool CheckInside(double x, double a, double b, double accuracy)
        {
            if ((x > a - accuracy && x < b + accuracy) || (x > b - accuracy && x < a + accuracy))
                return true;
            else return false;
        }
        public bool IsItYou(Point point)//Исправить название!
        {
            Point prevP = Points[Points.Count() - 1];
            foreach (Point p in Points)
            {
                if (Contain(prevP, p, point, width))
                {
                    return true;
                }
                prevP = p;
            }


            return false;
        }

        public void Move(Point delta)
        {
            for (int i = 0; i < Points.Count(); i++)
            {
                Point p = Points[i];
                Points[i] = new Point(p.X + delta.X, p.Y + delta.Y);
            }

        }
    }



}

