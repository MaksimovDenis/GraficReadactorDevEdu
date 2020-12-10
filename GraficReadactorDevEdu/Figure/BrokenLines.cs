using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
   public class BrokenLines : IFigure
    {
        public Point tmpPoint;
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
        
        //public void BrokeLinesFunc(Point prevPoint, Point endPoint,int tmp,int quantity)
        //{

        //    if (tmp < quantity && tmp != 0)
        //    {
        //        prevPoint = endPoint;

        //    }

        //    if (tmp == quantity - 1)
        //    {
        //        tmp = 0;
        //    }
        //    else
        //    {

        //        tmp++;
        //    }
        //}
    }
}
