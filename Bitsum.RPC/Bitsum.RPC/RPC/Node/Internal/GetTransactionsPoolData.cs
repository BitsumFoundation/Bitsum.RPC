
namespace Bitsum.RPC.Node.Internal
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class GetTransactionsPoolData
    {
        public class Request { }

        public class Response
        {
            [JsonProperty("transactions")]
            public List<TransactionPreview> Transactions { get; set; }
        }
    }
}
