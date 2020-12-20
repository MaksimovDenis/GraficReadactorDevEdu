using NUnit.Framework;
using System.Drawing;
using System;
using GraficReadactorDevEdu.Factor;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu.Tests.FigureTests
{
    [TestFixture]
    public class PTriangleTests
    {
        [Test]

        public void UpdateTest()
        {
            //arrange
            var factory = new PTriangleFactory();
            var ptriangle = new PTriangle(factory);
            var startPoint = new Point(0,0);
            var Point = new Point(2, 0);
            var endPoint = new Point(0, 2);
            //act
            ptriangle.Update(startPoint, endPoint);
            //assert        

            Assert.AreEqual(startPoint, ptriangle.Points[0]);
            Assert.AreEqual(endPoint, ptriangle.Points[1]);


        }
    }
}
