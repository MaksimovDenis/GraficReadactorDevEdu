using NUnit.Framework;
using System.Drawing;
using System;
using GraficReadactorDevEdu.Factor;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu.Tests.FigureTests
{

    [TestFixture]
    public class FreeTriangleTests
    {
        [Test]

        public void UpdateTest()
        {
            //arrange
            var factory = new FreeTriangleFactory();
            var freetriangle = new FreeTriangle(factory);
            var startPoint = new Point(0, 0);
            var endPoint = new Point(2, 0);
            //act
            freetriangle.Update(startPoint, endPoint);
            //assert        

            Assert.AreEqual(startPoint, freetriangle.Points[0]);
            Assert.AreEqual(endPoint, freetriangle.Points[1]);


        }
    }
}
