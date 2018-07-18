
namespace Bitsum.RPC.Node
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Block
    {
        [JsonProperty("header")]
        public BlockHeader Header { get; set; }

        [JsonProperty("transactions")]
        public List<TransactionPreview> Transactions { get; set; }
    }
}
