using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class AnyTests
    {
        [Test]
        public void FalseWhenEmpty()
        {
            var numbers = new List<Int32>();
            Assert.That(MyEnumerable.Any(numbers), Is.False);
        }

        [Test]
        public void TrueWhenNotEmpty()
        {
            var numbers = new[] { 1, 2, 3 };
            Assert.That(MyEnumerable.Any(numbers), Is.True);
        }

        [Test]
        public void ThrowsWhenNull()
        {
            IEnumerable<Int32> source = null;
            Assert.Throws<ArgumentNullException>(() => MyEnumerable.Any(source));
        }
    }

    [TestFixture]
    public class AnyWithPredicateTests
    {
        [Test]
        public void FalseWhenEmpty()
        {
            var numbers = new List<Int32>();
            Assert.That(MyEnumerable.Any(numbers, n => n > 0), Is.False);
        }

        [Test]
        public void TrueWhenNotEmpty()
        {
            var numbers = new[] { 1, 2, 3 };
            Assert.That(MyEnumerable.Any(numbers, n => n > 1), Is.True);
        }

        [Test]
        public void ThrowsWhenSourceIsNull()
        {
            IEnumerable<Int32> source = null;
            Assert.Throws<ArgumentNullException>(() => MyEnumerable.Any(source, n => n > 1));
        }

        [Test]
        public void ThrowsWhenPredicateIsNull()
        {
            var source = new[] { 1, 2, 3 }; 
            Assert.Throws<ArgumentNullException>(() => MyEnumerable.Any(source, null));
        }
    }
}
