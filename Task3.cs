using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
    namespace Task__3
{
    [TestFixture]
    public class Task3
    {
        [Test]
        public void test1_Sumof_n()
        {
            Assert.AreEqual(7, Sum_of_n(16));
        }
        [Test]
        public void test2_Sumof_n()
        {
            Assert.AreEqual(1, Sum_of_n(1234567));
        }
        [Test]
        public void test3_Sumof_n()
        {
            Assert.AreEqual(2, Sum_of_n(493193));
        }
        public int Sum_of_n(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += (number % 10);
                number = number / 10;
            }
            if (sum / 10 < 1)
            { return sum; }
            else { return Sum_of_n(sum); }
        }
    }
}
