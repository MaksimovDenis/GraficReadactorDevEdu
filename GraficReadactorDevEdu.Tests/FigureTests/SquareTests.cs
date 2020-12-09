using NUnit.Framework;
using System.Drawing;
using System;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu.Tests.FigureTests
{
    [TestFixture]
    public class SquareTests
    {
        [Test]

        public void GetPointsTest()
        {
            //arrange
            var square = new Square();
            var startPoint = new Point(0, 0);
            var Point1 = new Point(2, 0);
            var Point2 = new Point(2, 2);
            var endPoint = new Point(0, 2);
            
            //act
            var points = square.GetPoints(startPoint, endPoint);
            //assert        

            Assert.AreEqual(startPoint, points[0]);
            Assert.AreEqual(new Point (2,0), points[1]);
            Assert.AreEqual(new Point(2,2), points[2]);
            Assert.AreEqual(new Point(0,2), points[3]);




        }
    }
}
