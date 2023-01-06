using Microsoft.VisualStudio.TestTools.UnitTesting;

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