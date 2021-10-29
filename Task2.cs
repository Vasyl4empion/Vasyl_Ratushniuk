using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Task__2
{
    [TestFixture]
    public class Task2
    {
        [Test]
        public void test1_First_non_repeating_letter()
        {
            Assert.AreEqual('t', First_non_repeating_letter("stress"));
        }

        [Test]
        public void test2_First_non_repeating_letter()
        {
            Assert.AreEqual('T', First_non_repeating_letter("sTreSS"));
        }
        [Test]
        public void test3_First_non_repeating_letter()
        {
            Assert.AreEqual('-', First_non_repeating_letter("strtrs"));
        }
        public char First_non_repeating_letter(string row)
        {
            foreach (var element in row)
            {
                string newrow = row.ToLower().Remove(row.IndexOf(element), 1);
                if (!newrow.Contains(element))
                {
                    return element;
                }

            }
            return '-';
        }
    }
}
