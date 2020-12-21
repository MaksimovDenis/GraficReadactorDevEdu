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
        public BrokenLines(IFactory factorys)
        {
            factory = factorys;
        }

       
        public override void Draw(Graphics graphics, Pen pen)
        {

            graphics.DrawLine(pen, Points[0], Points[1]);
        }


        public override void Update(Point startPoint, Point endPoint)
        {

            Points = new List<Point>
            {
               startPoint,
               endPoint

            };
        }
        public override void DrawEndLine(Graphics grafics, Pen pen)
        {
            return;
        }

        public override void UpN(int quantity)
        {
            N = quantity;
        }

        public override void FillPolygon(Graphics graphics, Brush brush)
        {
        }

        public override void Veer(int text)
        {
            
        }
    }
}
