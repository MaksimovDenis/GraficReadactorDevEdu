using NUnit.Framework;
using System.Drawing;
using System;
using GraficReadactorDevEdu.Factor;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu.Tests.FigureTests
{  

    [TestFixture]
    public class FreePolygonTests
    {
        [Test]

        public void UpdateTest()
        {
            //arrange
            var factory = new FreePolygonFactory();
            var freepolygon = new FreePolygon(factory);
            var startPoint = new Point(0, 0);
            var endPoint = new Point(2, 0);
            //act
            freepolygon.Update(startPoint, endPoint);
            //assert        

            Assert.AreEqual(startPoint, freepolygon.Points[0]);
            Assert.AreEqual(endPoint, freepolygon.Points[1]);


        }
    }
}
