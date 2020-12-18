using GraficReadactorDevEdu.Factor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
    public class Pen : AFigure
    {

        public Pen(IFactory factorys)
        {
            factory = factorys;
        }
        grafics = Graphics.FromImage(mainBm);
                        //    grafics.DrawLine(pen, prevPoint, e.Location);
                        //    prevPoint = e.Location;
        public override void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, );
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