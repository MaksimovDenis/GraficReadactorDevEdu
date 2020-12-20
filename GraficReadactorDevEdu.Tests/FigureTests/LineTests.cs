using NUnit.Framework;
using System.Drawing;
using System;
using GraficReadactorDevEdu.Factor;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu.Tests
{
    [TestFixture]
    public class LineTests
    {

        [Test]

        /*[TestCase(5, 5)]*/
        public void UpdateTest()
        {
            //arrange
            var factory = new LineFactory();
            var line = new Line(factory);
            var startPoint = new Point(0, 0);
            var endPoint = new Point(2, 0);
            //act
            //var point = new List<Point>;
            line.Update(startPoint, endPoint);
            //assert        


            Assert.AreEqual(startPoint, line.Points[0]);
            Assert.AreEqual(endPoint, line.Points[1]);


        }
    }
}
