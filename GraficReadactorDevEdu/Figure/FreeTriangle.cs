using GraficReadactorDevEdu.Factor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
    public class FreeTriangle : AFigure
    {


        public FreeTriangle(IFactory factorys)
        {
            factory = factorys;

        }

        public override void Draw(Graphics graphics, Pen pen)
        {

            graphics.DrawLine(pen, Points[0], Points[1]);

        }

        public override void DrawEndLine(Graphics grafics, Pen pen)
        {
            if (tmp == 0)
            {
                grafics.DrawLine(pen, begin, endPoint);
            }
        }

        public override void Update(Point startPoint, Point endPoint)
        {

            Points = new List<Point>
            {
               startPoint,
               endPoint

            };
        }

        public override void UpN(int quantity)
        {
            N = 2;
        }
    }
}