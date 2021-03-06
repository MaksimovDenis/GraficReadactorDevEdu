﻿using GraficReadactorDevEdu.Factor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficReadactorDevEdu.Figure
{
    public class Square : AFigure
    {
        public Square(IFactory factorys)
        {
            factory = factorys;
        }

        public override void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawPolygon(pen,Points.ToArray());
        }

        public override void Update(Point startPoint, Point endPoint)
        {
            Points = new List<Point>
            {
               startPoint,
               new Point (endPoint.X, startPoint.Y),
              new Point (endPoint.X, endPoint.X+startPoint.Y-startPoint.X),
               new Point (startPoint.X,endPoint.X+startPoint.Y-startPoint.X)
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

        public override void Veer(int text)
        {
            Point r = new Point(Points[0].X + ((Points[1].X - Points[0].X) / 2),
                          Points[0].Y + ((Points[3].Y - Points[0].Y) / 2)); // точка относительно которой поворачиваем
            int angle = text; //угол поворота
            double angleRadian = angle * Math.PI / 180; //переводим угол в радианты
            Point[] rara = new Point[Points.Count()]; //для хранения новых координат обхекта
            for (int j = 0; j < Points.Count(); j++)
            {
                int x = (int)((Points[j].X - r.X) * Math.Cos(angleRadian) - (Points[j].Y - r.Y) * Math.Sin(angleRadian) + r.X);
                int y = (int)((Points[j].X - r.X) * Math.Sin(angleRadian) + (Points[j].Y - r.Y) * Math.Cos(angleRadian) + r.Y);
                rara[j] = new Point(x, y);
            }

            for (int i = 0; i < Points.Count(); i++)
            {
                Points[i] = rara[i];

            }
        }
    }
}
