﻿using GraficReadactorDevEdu.Factor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
    class Triangle : AFigure//Равнобедренный треугольник
    {
        public Triangle(IFactory factorys)
        {
            factory = factorys;
        }

        public override void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawPolygon(pen, Points.ToArray());
        }

        public override void Update(Point startPoint, Point endPoint)
        {
            int tmp = endPoint.X - startPoint.X;
            Points = new List<Point>
            {
               startPoint,
               new Point (endPoint.X, endPoint.Y),
               new Point (startPoint.X-tmp, endPoint.Y),
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
            graphics.FillPolygon(brush, Points.ToArray());
        }
    }
}

