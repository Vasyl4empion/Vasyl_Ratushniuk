using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Task__1
{
    [TestFixture]
    public class Task1
    {
        [Test]
        public void test1_getintegers()
        {
            Assert.AreEqual(new List<object> { 1, 2 }, Getintegers(new List<object> { 1, 2, 'a', 'b' }));
        }
        [Test]
        public void test2_getintegers()
        {
            Assert.AreEqual(new List<object> { 1, 2, 0, 15 }, Getintegers(new List<object> { 1, 2, 'a', 'b', 0, 15 }));
        }
        public List<object> Getintegers(List<object> list)
        {
            int a = 5;
            List<object> newlist = new List<object> { };
            newlist.AddRange(list.Where(x => x.GetType() == a.GetType()));
            return newlist;
        }
    }
}
