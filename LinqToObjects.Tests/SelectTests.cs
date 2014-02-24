using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class SelectTests
    {
        [Test]
        public void SelectWhenEmpty()
        {
            var numbers = new List<Int32>();
            Assert.That(MyEnumerable.Select(numbers, n => n), Is.Empty);
        }

        [Test]
        public void SelectWhenNotEmpty()
        {
            var numbers = new[] { 1, 2, 3 };
            Assert.That(MyEnumerable.Select(numbers, n => n + 1), Is.EquivalentTo(new[] { 2, 3, 4 }));
        }

        [Test]
        public void ThrowsWhenSourceIsNull()
        {
            IEnumerable<Int32> numbers = null;
            Assert.Throws<ArgumentNullException>(() => MyEnumerable.Select(numbers, n => n + 1));
        }
    }
}
