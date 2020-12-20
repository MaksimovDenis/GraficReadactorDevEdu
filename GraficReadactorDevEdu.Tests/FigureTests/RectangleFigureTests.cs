using NUnit.Framework;
using System.Drawing;
using System;
using GraficReadactorDevEdu.Factor;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu.Tests.FigureTests
{
    [TestFixture]
    public class RectangleFigureTests
    {
        [Test]

        public void UpdateTest()
        {
            //arrange
            var factory = new RectangleFigureFactory();
            var rectangleFigure = new RectangleFigure(factory);
            var startPoint = new Point(0, 0);
            var endPoint = new Point(2, 2);
            var Point1 = new Point(startPoint.X, endPoint.Y);
            var Point2 = new Point(endPoint.X, startPoint.Y);
            //act
            rectangleFigure.Update(startPoint, endPoint);
            //assert        

            Assert.AreEqual(startPoint, rectangleFigure.Points[0]);
            Assert.AreEqual(Point1, rectangleFigure.Points[1]);
            Assert.AreEqual(endPoint, rectangleFigure.Points[2]);
            Assert.AreEqual(Point2, rectangleFigure.Points[3]);

        }
    }
}