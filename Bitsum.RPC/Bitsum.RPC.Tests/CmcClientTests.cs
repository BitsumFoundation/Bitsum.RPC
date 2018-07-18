using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitsum.RPC.Tests
{
    using Cmc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Diagnostics;

    [TestClass]
    public class CmcClientTests
    {
        private readonly CmcClient client = new CmcClient();

        [TestMethod]
        public void GetDataTest()
        {
            var result = client.GetData().Result;
            Debug.WriteLine($"{JsonConvert.SerializeObject(result, Formatting.Indented)}");
        }
    }
}
