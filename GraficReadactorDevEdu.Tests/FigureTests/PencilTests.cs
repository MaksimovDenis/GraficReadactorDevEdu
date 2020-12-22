using NUnit.Framework;
using System.Drawing;
using System;
using GraficReadactorDevEdu.Factor;
using GraficReadactorDevEdu.Figure;

namespace GraficReadactorDevEdu.Tests.FigureTests
{
    [TestFixture]
    public class PencilTests
    {

        [Test]

        /*[TestCase(5, 5)]*/
        public void UpdateTest()
        {
            //arrange
            var factory = new PenFactory();
            var pencil = new Pencil(factory);
            var startPoint = new Point(0, 0);
            var endPoint = new Point(2, 0);
            //act
            //var point = new List<Point>;
            pencil.Update(startPoint, endPoint);
            //assert        


            Assert.AreEqual(startPoint, pencil.Points[0]);
            Assert.AreEqual(endPoint, pencil.Points[1]);


        }
    }
}
