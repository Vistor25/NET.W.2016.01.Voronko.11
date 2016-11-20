using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Tests
{
    [TestFixture]
    public class SetTests
    {
        private static readonly object[] sourceListsAdd =
        {
            new object[] { new List<string>{ "Victor","Denis","Ivan"},
                           new []{ "Victor", "Denis", "Ivan", "Victor", "Denis", "Ivan" } },

        };

        [Test, TestCaseSource(nameof(sourceListsAdd))]
        public void SetTestAdd(List<int> expectedResult, params string[] values)
        {
            var result = new Set<string>();
            foreach (var value in values)
            {
                result.Add(value);
            }

            Assert.AreEqual(expectedResult, new List<string>(result));
        }
        private static readonly object[] sourceListRemove =
        {
            new object[] {new List<string> { "Victor", "Denis", "Ivan" }, new[] { "Denis", "Ivan" } }
        };
        [Test, TestCaseSource(nameof(sourceListRemove))]
        public void SetTestRemove(List<string> expectedResult, params string[] values)
        {
            var result = new Set<string>();
            foreach (var value in values)
            {
                result.Add(value);
            }
            result.Remove("Victor");
            Assert.AreEqual(expectedResult, new List<string>(result));
        }
        private static readonly object[] sourceListSymmetricDifference = new object[]
        {
            new Set<string> { "Victor", "Denis", "Ivan" },
            new Set<string> {"1", "2", "3", "Victor", "Denis", "Sharp" },
            new List<string> { "Victor", "Denis" }
        };
        [Test, TestCaseSource(nameof(sourceListSymmetricDifference))]
        public void SetTestSymmetricDifference(Set<string> firstset, Set<string> anotherset, List<string> expectedresult)
        {
            firstset.SymmetricDifference(anotherset);
            Assert.AreEqual(expectedresult, firstset);
        }

    }
}
