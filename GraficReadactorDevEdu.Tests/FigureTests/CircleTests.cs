using NUnit.Framework;
using System.Drawing;
using System;
using GraficReadactorDevEdu.Factor;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu.Tests
{  
    [TestFixture]
    public class CircleTests

    {
        [Test]

        /*[TestCase(5, 5)]*/
        public void UpdateTest()
        {
            //arrange
            var factory = new CircleFactory();
            var circle = new Circle(factory);
            var startPoint = new Point(0, 0);
            var endPoint = new Point(2, 0);
            //act
           circle.Update(startPoint, endPoint);
            //assert        


            Assert.AreEqual(startPoint, circle.Points[0]);
            Assert.AreEqual(endPoint, circle.Points[1]);


        }
    }

}