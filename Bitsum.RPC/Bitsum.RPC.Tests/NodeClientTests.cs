
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitsum.RPC.Tests
{
    using Node;
    using Newtonsoft.Json;

    [TestClass]
    public class NodeClientTests
    {
        private readonly NodeClient client = new NodeClient("http://127.0.0.1:28081");

        [TestMethod]
        public void GetStatusTest()
        {
            var result = client.GetStatus().Result;
            Debug.WriteLine($"{JsonConvert.SerializeObject(result, Formatting.Indented)}");
        }

        [TestMethod]
        public void GetBlockByHeightTest()
        {
            var result = client.GetBlock(100).Result;
            Debug.WriteLine($"{JsonConvert.SerializeObject(result, Formatting.Indented)}");
        }

        [TestMethod]
        public void GetBlockByHashTest()
        {
            var result = client.GetBlock("4517f33cdf1f39d1d884a7904e003972c7bbc300d57c16014780fa36c1aa62c9").Result;
            Debug.WriteLine($"{JsonConvert.SerializeObject(result, Formatting.Indented)}");
        }

        [TestMethod]
        public void GetTransactionTest()
        {
            var result = client.GetTransaction("6f47c4e258cdbc900580a83b45c6b0bdc98eaef8e86395ff990f522048c7d9c1").Result;
            Debug.WriteLine($"{JsonConvert.SerializeObject(result, Formatting.Indented)}");
        }

        [TestMethod]
        public void GetTransactionsPoolTest()
        {
            var result = client.GetTransactionsPool().Result;
            Debug.WriteLine($"{JsonConvert.SerializeObject(result, Formatting.Indented)}");
        }
    }
}
