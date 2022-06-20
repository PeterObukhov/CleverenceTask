using Cleverence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleverenceTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [DataRow(5000, true)]
        [DataRow(500, false)]
        public void AsyncCallerTests(int ms, bool expected)
        {
            var handler = new EventHandler((sender, args) => Thread.Sleep(1000));
            var caller = new AsyncCaller(handler);

            Assert.AreEqual(expected, caller.Invoke(ms, null, EventArgs.Empty));
        }

        [TestMethod]
        public void ServerTests()
        {
            Parallel.For(0, 1000, i =>
            {
                Server.AddToCount(1);
            });
            Assert.AreEqual(1000, Server.GetCount());
        }
    }
}
