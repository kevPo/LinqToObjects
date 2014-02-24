using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LinqToObjects.Tests
{
    [TestFixture]
    public class CountTests
    {
        [Test]
        public void CountWhenEmpty()
        {
            var numbers = new List<Int32>();
            Assert.That(MyEnumerable.Count(numbers), Is.EqualTo(0));
        }

        [Test]
        public void CountWhenNotEmpty()
        {
            var numbers = new[] { 1, 2, 3, 4 };
            Assert.That(MyEnumerable.Count(numbers), Is.EqualTo(4));
        }

        [Test]
        public void ThrowsWhenSourceIsNull()
        {
            IEnumerable<Int32> numbers = null;
            Assert.Throws<ArgumentNullException>(() => MyEnumerable.Count(numbers));
        }

        [Test, Ignore]
        public void ThrowsWhenOverflowOccurs()
        {
            Assert.Throws<OverflowException>(() => MyEnumerable.Count(GetBigSequence()));
        }

        private IEnumerable<Int64> GetBigSequence()
        {
            for (var i = 0; i < Int32.MaxValue; i++)
                yield return i;

            yield return 0;
        }
    }
}
