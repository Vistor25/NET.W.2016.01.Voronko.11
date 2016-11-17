using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tests
{
    [TestFixture]
    public class QueueTests
    {
        private static readonly object[] sourceListsEnqueue =
        {
            new object[] { new List<int>{ 2, 7, 8, 5, 6, 4, 3, 11},
                           new []{ 2, 7, 8, 5, 6, 4, 3, 11} },

        };

        [Test, TestCaseSource(nameof(sourceListsEnqueue))]
        public void QueueTestEnqueue(List<int> expectedResult, params int[] values)
        {
            var result = new Queue<int>();
            foreach (var value in values)
            {
                result.Enqueue(value);
            }

            Assert.AreEqual(expectedResult, new List<int>(result));
        }
        private static readonly object[] sourceListDequeue =
        {
            new object[] {new List<int> { 2,4,6,7,8}, new[] {2} }
        };
        [Test, TestCaseSource(nameof(sourceListDequeue))]
        public void QueueTestDequeue(List<int> expectedResult, params int[] values)
        {
            var result = new Queue<int>();
            foreach(var value in values)
            {
                result.Enqueue(value);
            }
            for (int i = 0; i < values.Length - 1; i++)
            {
                result.Dequeue();
            }
            Assert.AreEqual(expectedResult, new List<int>(result))
        }
    }
}

