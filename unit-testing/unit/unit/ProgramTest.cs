using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit
{
    using NUnit.Framework;
    [TestFixture]
    class ProgramTest
    {
        [Test]
        [TestCase(-1, -2, -3)]
        [MaxTime(5)]
        public void NegativeValues(double value1, double value2, double value3)
        {
            if (Program.isTriangle(value1,value2,value3) == true)
                Assert.Fail("Values cannot be less than 0");
        }

        [Test]
        [TestCase(0, 0, 1)]
        [MaxTime(5)]
        public void ZeroValues(double value1, double value2, double value3)
        {
            if (Program.isTriangle(value1, value2, value3) == true)
                Assert.Fail("Values cannot be equal 0");
        }

        [Test]
        [TestCase(-1, 0, 1)]
        [Pairwise()]
        [MaxTime(10)]
        public void MixedValues(double value1, double value2, double value3)
        {
            if (Program.isTriangle(value1, value2, value3) == true)
                Assert.Fail("Values cannot be less or equal 0");
        }

        [Test]
        [TestCase(1,2,3)]
        [MaxTime(5)]
        public void RightValues(double value1, double value2, double value3)
        {
            if (Program.isTriangle(value1, value2, value3) == false)
                Assert.Fail("Something wrong with logic inside the method");
        }

        [Test]
        [TestCase(1, 2, 5)]
        [MaxTime(5)]
        public void NotRightValues(double value1, double value2, double value3)
        {
            if (Program.isTriangle(value1, value2, value3) == true)
                Assert.Fail("Something wrong with logic inside the method");
        }

        [Test]
        [TestCase(Double.MaxValue, Double.MaxValue, Double.MaxValue)]
        [MaxTime(10)]
        public void OverflowValues(double value1, double value2, double value3)
        {
            if (Program.isTriangle(value1, value2, value3) == true)
                Assert.Fail("Something wrong with logic inside the method");
        }
    }
}
