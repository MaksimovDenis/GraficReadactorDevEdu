using NUnit.Framework;
using System.Drawing;
using System;
using GraficReadactorDevEdu.Factor;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu.Tests.FigureTests
{
    [TestFixture]
    public class BrokenLinesTests
    {
        [Test]

        public void UpdateTest()
        {
            //arrange
            var factory = new BrokenLinesFactory();
            var brokenlines = new BrokenLines(factory);
            var startPoint = new Point(0, 0);
            var endPoint = new Point(2, 0);
            //act
            brokenlines.Update(startPoint, endPoint);
            //assert        

            Assert.AreEqual(startPoint, brokenlines.Points[0]);
            Assert.AreEqual(endPoint, brokenlines.Points[1]);


        }
    }
}
