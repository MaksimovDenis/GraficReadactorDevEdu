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
        private int tmp;
        public BrokenLines(IFactory factorys)
        {
            factory = factorys;
            tmp = 0;
        }

        public Point tmpPoint;
        public override void Draw(Graphics graphics, Pen pen, Point[] pts)
        {

            
            graphics.DrawLine(pen, pts[0], pts[1]);

        }
        //public void MousDown()
        //{
        //    if (tmp < N && tmp != 0)
        //    {
        //        prevPoint = endPoint;

        //    }

        //    if (tmp == N - 1)
        //    {

        //        N = 0;
        //    }
        //    else
        //    {

        //        N++;
        //    }
        //}
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
