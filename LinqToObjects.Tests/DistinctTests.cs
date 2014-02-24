using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class DistinctTests
    {
        [Test]
        public void DistinctWhenEmpty()
        {
            var numbers = new List<Int32>();
            Assert.That(MyEnumerable.Distinct(numbers), Is.Empty);
        }

        [Test]
        public void Distinct()
        {
            var numbers = new[] { 1, 2, 3, 3 };
            Assert.That(MyEnumerable.Distinct(numbers), Is.EquivalentTo(new[] { 1, 2, 3 }));
        }

        [Test]
        public void ThrowsWhenSourceIsNull()
        {
            IEnumerable<Int32> numbers = null;
            Assert.Throws<ArgumentNullException>(() => MyEnumerable.Distinct(numbers));
        }
    }
}
