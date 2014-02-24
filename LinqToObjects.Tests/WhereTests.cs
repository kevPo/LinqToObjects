using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class WhereTests
    {
        [Test]
        public void WhereWhenEmpty()
        {
            var numbers = new List<Int32>();
            var numbersGreaterThanFive = MyEnumerable.Where(numbers, n => n > 5);
            Assert.That(numbersGreaterThanFive, Is.Empty);
        }

        [Test]
        public void WhereWhenNotEmpty()
        {
            var numbers = new[] { 1, 2, 3 };
            var numbersGreaterThanOne = MyEnumerable.Where(numbers, n => n > 1);
            Assert.That(numbersGreaterThanOne, Is.EquivalentTo(new[] { 2, 3 }));
        }

        [Test]
        public void ThrowsWhenSourceIsNull()
        {
            IEnumerable<Int32> source = null;
            Assert.Throws<ArgumentNullException>(() => MyEnumerable.Where(source, n => n > 0));
        }

        [Test]
        public void ThrowsWhenPredicateIsNull()
        {
            IEnumerable<Int32> source = new[] { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => MyEnumerable.Where(source, (Func<Int32, Boolean>)null));
        }
    }

    [TestFixture]
    public class WhereWithIndexTests
    {
        [Test]
        public void WhereWhenEmpty()
        {
            var numbers = new List<Int32>();
            var allNumbers = MyEnumerable.Where(numbers, (n, i) => i >= 0);
            Assert.That(allNumbers, Is.Empty);
        }

        [Test]
        public void WhereWhenNotEmpty()
        {
            var numbers = new[] { 1, 2, 3 };
            var numbersGreaterThanOne = MyEnumerable.Where(numbers, (n,i) => i > 0);
            Assert.That(numbersGreaterThanOne, Is.EquivalentTo(new[] { 2, 3 }));
            
        }

        [Test]
        public void ThrowsWhenSourceIsNull()
        {
            IEnumerable<Int32> source = null;
            Assert.Throws<ArgumentNullException>(() => MyEnumerable.Where(source, (n,i) => i > 0));
        }

        [Test]
        public void ThrowsWhenPredicateIsNull()
        {
            IEnumerable<Int32> source = new[] { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => MyEnumerable.Where(source, (Func<Int32, Int32, Boolean>)null));
        }
    }
}
