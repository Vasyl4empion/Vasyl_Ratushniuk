using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Extratask__1
{
    [TestFixture]
    public class Extratask1
    {
        [Test]
        public void test1_biggerinteger()
        {
            Assert.AreEqual(2071, bigger_integer(2017));
        }
        [Test]
        public void test2_biggerinteger()
        {
            Assert.AreEqual(-1, bigger_integer(1111));
        }
        [Test]
        public void test3_biggerinteger()
        {
            Assert.AreEqual(-1, bigger_integer(6));
        }
        [Test]
        public void test4_biggerinteger()
        {
            Assert.AreEqual(-1, bigger_integer(54321));
        }
        [Test]
        public void test5_biggerinteger()
        {
            Assert.AreEqual(43567, bigger_integer(37654));
        }
        static public List<int> replace_elements(List<int> array, int x, int y)
        {
            int tmp;
            tmp = array[x];
            array[x] = array[y];
            array[y] = tmp;
            return array;
        }
        static public double bigger_integer(int number)
        {
            List<int> digits = new List<int> { };
            double getnumber = 0;
            int min, indexofmin;
            bool flag = false;
            while (number > 0)
            {
                digits.Add(number % 10);//fulling our list of digirs in numner in reverse position: 1234->[4,3,2,1]
                number /= 10;
            }
            if (digits.Count() <= 1) { return -1; }
            for (int i = 0; i < digits.Count() - 1; i++)
            {
                if (digits[i] > digits[i + 1])
                {
                    min = digits[i];
                    indexofmin = i;
                    for (int j = 0; j < i; j++)
                    {
                        if (digits[j] > digits[i + 1] && digits[j] < min)
                        {
                            min = digits[j];
                            indexofmin = j;
                        }
                    }
                    replace_elements(digits, i + 1, indexofmin);
                    digits.Reverse(0, i + 1);
                    flag = true;
                    break;
                }
            }
            if (flag == false) { return -1; }
            for (int i = 0; i < digits.Count(); i++)
            {
                getnumber += digits[i] * Math.Pow(10, i);
            }
            return getnumber;
        }
    }
}
