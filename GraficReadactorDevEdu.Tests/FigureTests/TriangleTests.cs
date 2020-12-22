using NUnit.Framework;
using System.Drawing;
using System;
using GraficReadactorDevEdu.Factor;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu.Tests.FigureTests
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]

        public void UpdateTest()
        {
            //arrange
            var factory = new TriangleFactory();
            var triangle = new Triangle(factory);
            var startPoint = new Point(1, 1);                     
            var endPoint = new Point(3,2);
            var Point1 = new Point(-1,2);

            //act
            triangle.Update(startPoint, endPoint);
            //assert        

            Assert.AreEqual(startPoint, triangle.Points[0]);
            Assert.AreEqual(Point1, triangle.Points[2]);
            //Assert.AreEqual(Point2, triangle.Points[0]);
            Assert.AreEqual(endPoint, triangle.Points[1]);


        }
    }
}
