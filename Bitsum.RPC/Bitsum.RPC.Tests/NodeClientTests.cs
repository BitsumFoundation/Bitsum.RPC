using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitsum.RPC.Tests
{
    [TestClass]
    public class NodeClientTests
    {
        private readonly NodeClient client = new NodeClient("http://127.0.0.1:28081");

        [TestMethod]
        public void GetStatusTest()
        {
            Status status = client.GetStatus().Result;
            Debug.WriteLine($"{status.LocalHeight}/{status.GlobalHeight}");
        }

    }
}
