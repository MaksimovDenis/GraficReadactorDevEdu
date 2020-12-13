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
        List<Point> Points { get; set; }
        Color color { get; set; }
        int width { get; set; }
        void Update(Point startPoint, Point endPoint);
        bool Check();
        bool IsItYou(Point point);
        void Move(Point delta);
        void Draw(Graphics graphics, Pen pen, Point[] pts);
       
    }
}
