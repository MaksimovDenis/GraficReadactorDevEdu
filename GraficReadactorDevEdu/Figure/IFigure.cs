using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GraficReadactorDevEdu.Figure
{
    public interface IFigure
    {
        Point[] GetPoints(Point startPoint, Point endPoint);

        void Draw(Graphics graphics, Pen pen, Point[] pts);
       
    }
}
