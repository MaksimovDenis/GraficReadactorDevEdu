using NUnit.Framework;
using System.Drawing;
using System;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu.Tests.FigureTests
{
    [TestFixture]
    public class BrokenLinesTests
    {
        [Test]

        public void GetPointsTest()
        {  
            //arrange
            var brokenlines = new BrokenLines();
            var startPoint = new Point(0, 0);
            var endPoint = new Point(2, 0);
            //act
            var points = brokenlines.GetPoints(startPoint, endPoint);
            //assert        

            Assert.AreEqual(startPoint, points[0]);
            Assert.AreEqual(endPoint, points[1]);


        }
    }
}
