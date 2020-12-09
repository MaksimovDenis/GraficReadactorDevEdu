using NUnit.Framework;
using System.Drawing;
using System;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu.Tests.FigureTests
{
    [TestFixture]
    public class PTriangleTests
    {
        [Test]

        public void GetPointsTest()
        {
            //arrange
            var ptriangle = new PTriangle();
            var startPoint = new Point(0, 0);
            var Point = new Point(2, 0);
            var endPoint = new Point(0, 2);
            //act
            var points = ptriangle.GetPoints(startPoint, endPoint);
            //assert        

            Assert.AreEqual(startPoint, points[0]);
            Assert.AreEqual(endPoint, points[1]);


        }
    }
}