using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Task__5
{
    [TestFixture]
    public class Task5
    {
        [Test]
        public void test1_Meeting()
        {
            string task = "Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            string expected = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";
            Assert.AreEqual(expected, Meeting(task));
        }
        [Test]
        public void test2_Meeting()
        {
            string task = "James:Bond;Vasyl:Ratushniuk;Alisa:Bond;Maria:Ratushniuk;Alex:Davidson;Anthony:Duglas";
            string expected = "(BOND, ALISA)(BOND, JAMES)(DAVIDSON, ALEX)(DUGLAS, ANTHONY)(RATUSHNIUK, MARIA)(RATUSHNIUK, VASYL)";
            Assert.AreEqual(expected, Meeting(task));
        }
        class Guests
        {
            public string name;
            public string surname;
        }
        public string Meeting(string visitors)
        {
            string upper_visitors = visitors.ToUpper();
            List<string> splitted = new List<string> { };
            splitted.AddRange(upper_visitors.Split(";"));
            List<Guests> guests = new List<Guests> { };
            foreach (var el in splitted)
            {
                guests.Add(new Guests { name = el.Split(":")[0], surname = el.Split(":")[1] });
            }
            var SortedGuests = guests.OrderBy(x => x.surname).ThenBy(x => x.name);
            string sorted = "";
            foreach (var el in SortedGuests)
            {
                sorted += "(" + el.surname + ", " + el.name + ")";
            }
            return sorted;
        }
    }
}
