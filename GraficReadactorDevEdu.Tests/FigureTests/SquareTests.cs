using NUnit.Framework;
using System.Drawing;
using System;
using GraficReadactorDevEdu.Factor;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu.Tests.FigureTests
{
    [TestFixture]
    public class SquareTests
    {
        [Test]

        public void UpdateTest()
        {
            //arrange
            var factory = new SquareFactory();
            var square = new Square(factory);
            var startPoint = new Point(0, 0);
            var Point1 = new Point(2, 0);
            var Point2 = new Point(2,2);
            var Point3 = new Point(0, 2);
            var endPoint = new Point(2, 2);
            
            //act
            square.Update(startPoint, endPoint);
            //assert        

            Assert.AreEqual(startPoint, square.Points[0]);
            Assert.AreEqual(Point1, square.Points[1]);
            Assert.AreEqual(Point2, square.Points[2]);
            Assert.AreEqual(Point3, square.Points[3]);

            //Assert.AreEqual(endPoint, square.Points[3]);




        }
    }
}
