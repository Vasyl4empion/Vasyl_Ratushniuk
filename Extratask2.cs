using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Extratask__2
{   [TestFixture]
    public class Extratask2
    {
        [Test]
        public void test1_IPv4_type() {
            Assert.AreEqual("0.0.0.0", IPv4_type(0));
        }
        [Test]
        public void test2_IPv4_type()
        {
            Assert.AreEqual("128.32.10.1", IPv4_type(2149583361));
        }
        [Test]
        public void test3_IPv4_type()
        {
            Assert.AreEqual("0.0.1.44", IPv4_type(300));
        }
        static public List<int> Binary_form(long number)
        {
            List<int> array = new List<int> { };
            do
            {
                array.Add(Convert.ToInt32(number % 2));
                number = number / 2;

            } while (number != 0);
            int amount = array.Count();
            for (int i = 0; i < 32 - amount; i++)
            {
                array.Add(0);
            }
            array.Reverse();
            return array;
        }
        static public string IPv4_type(long number)
        {
            List<int> ipv4_list = new List<int> { 0, 0, 0, 0 };
            for (int i = 0; i < 8; i++)
            {
                ipv4_list[0] += Convert.ToInt32(Binary_form(number)[i] * Math.Pow(2, 7 - i));
                ipv4_list[1] += Convert.ToInt32(Binary_form(number)[i + 8] * Math.Pow(2, 7 - i));
                ipv4_list[2] += Convert.ToInt32(Binary_form(number)[i + 16] * Math.Pow(2, 7 - i));
                ipv4_list[3] += Convert.ToInt32(Binary_form(number)[i + 24] * Math.Pow(2, 7 - i));
            }
            string ipv4_string = "";
            ipv4_string += ipv4_list[0] + "." + ipv4_list[1] + "." + ipv4_list[2] + "." + ipv4_list[3];
            return ipv4_string;
        }
    }
}
