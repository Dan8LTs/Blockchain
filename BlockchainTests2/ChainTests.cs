using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blockchain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Tests
{
    [TestClass()]
    public class ChainTests
    {
        [TestMethod()]
        public void ChainTest()
        {
            var chain = new Chain();
            chain.Add("LTs", "Admin");

            Assert.AreEqual("LTs", chain.Last.Data);
        }

        [TestMethod()]
        public void CheckTest()
        {
            var chain = new Chain();
            chain.Add("Hello, C#", "Admin");
            chain.Add("LTs", "Danil");
            Assert.IsTrue(chain.Check());
        }
    }
}