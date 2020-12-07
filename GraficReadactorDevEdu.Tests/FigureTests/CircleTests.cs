using NUnit.Framework;
using System.Drawing;
using System;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu.Tests
{  
    [TestFixture]
    public class CircleTests

    {
        [Test]

        /*[TestCase(5, 5)]*/
        public void GetPointsTest()
        {  
            //arrange
            var circle = new Circle();
            var startPoint = new Point(0, 0);
            var endPoint = new Point(2, 0);
            //act
            var points = circle.GetPoints(startPoint, endPoint);
            //assert        


            Assert.AreEqual(startPoint, points[0]);
            Assert.AreEqual(endPoint, points[1]);


        }
    }

}