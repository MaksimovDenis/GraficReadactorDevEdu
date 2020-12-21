using NUnit.Framework;
using System.Drawing;
using System;
using GraficReadactorDevEdu.Factor;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu.Tests.FigureTests
{

    [TestFixture]
    public class EllipseTests
    {
        [Test]

        public void UpdateTest()
        {
            //arrange
            var factory = new EllipseFactory();
            var ellipse = new Ellipse(factory);
            var startPoint = new Point(0, 0);
            var endPoint = new Point(2, 0);
            //act
            ellipse.Update(startPoint, endPoint);
            //assert        

            Assert.AreEqual(startPoint, ellipse.Points[0]);
            Assert.AreEqual(endPoint, ellipse.Points[1]);


        }
    }
}
