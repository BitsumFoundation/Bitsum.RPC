
#pragma warning disable IDE1006

namespace Bitsum.RPC.NodeData
{
    class StatusData
    {
        public class Request
        {
        }

        public class Response 
        {
            public uint top_known_block_height { get; set; }

            public uint top_block_height { get; set; }

            public ulong top_block_difficulty { get; set; }

            public uint top_block_timestamp { get; set; }

            public string top_block_hash { get; set; }

            public uint top_block_timestamp_median { get; set; }

            public ulong recommended_fee_per_byte { get; set; }

            public uint transaction_pool_version { get; set; }

            public uint incoming_peer_count { get; set; }

            public uint outgoing_peer_count { get; set; }

            public uint next_block_effective_median_size { get; set; }
        }
    }
}
