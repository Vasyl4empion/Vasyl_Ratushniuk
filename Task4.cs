using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Task__4
{
    [TestFixture]
    public class Task4
    {
        [Test]
        public void test1_Number_of_pairs()
        {
            Assert.AreEqual(4, Number_of_pairs(new List<int> { 1, 3, 6, 2, 2, 0, 4, 5 }, 5));
        }
        [Test]
        public void test2_Number_of_pairs()
        {
            Assert.AreEqual(5, Number_of_pairs(new List<int> { 1, 3, 6, 2, 2, 0, 4, 1, 5 }, 6));
        }
        [Test]
        public void test3_Number_of_pairs()
        {
            Assert.AreEqual(0, Number_of_pairs(new List<int> { 1, 3, 6, 2, 2 }, 10));
        }
        public int Number_of_pairs(List<int> list, int number)
        {
            int counter = 0;
            for (int i = 0; i < list.Count(); i++)
            {
                for (int j = list.Count() - 1; j > i; j--)
                {
                    if (list[i] + list[j] == number)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
    }
}
