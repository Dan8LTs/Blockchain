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
    public class BlockTests
    {
        [TestMethod()]
        public void SerializeTest()
        {
            var block = new Block();
            var result = block.Serialize();
            var expected = "{\"Created\":\"\\/Date(1630011600000)\\/\",\"Data\":\"Hello, C#!\",\"Hash\":\"e7eef1f07f1625e1e081062e8d0354db5183a5b26dceb43fbcf6bfe1c0711910\",\"PreviousHash\":\"11111\",\"User\":\"Admin\"}";

            Assert.AreEqual(result, expected);
        }

        [TestMethod()]
        public void DeserializeTest()
        {
            var block = new Block();
            var result = block.Serialize();
            var resultBlock = Block.Deserialize(result);

            Assert.AreEqual(block.Hash, resultBlock.Hash);
            Assert.AreEqual(block.Created, resultBlock.Created);
            Assert.AreEqual(block.Data, resultBlock.Data);
            Assert.AreEqual(block.PreviousHash, resultBlock.PreviousHash);
            Assert.AreEqual(block.User, resultBlock.User);
        }
    }
}