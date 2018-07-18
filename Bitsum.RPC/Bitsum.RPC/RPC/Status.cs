


namespace Bitsum.RPC
{
    using Newtonsoft.Json;

    public class Status
    {
        [JsonProperty("top_block_height")]
        public uint TopBlockHeight { get; set; }

        [JsonProperty("top_block_hash")]
        public string TopBlockHash { get; set; }

        [JsonProperty("top_block_timestamp")]
        public uint TopBlockTimestamp { get; set; }

        [JsonProperty("top_block_difficulty")]
        public uint TopBlockDifficulty { get; set; }

        [JsonProperty("top_block_timestamp_median")]
        public uint TopBlockTimestampMedian { get; set; }

        [JsonProperty("top_known_block_height")]
        public uint NetworkHeight { get; set; }

        [JsonProperty("next_block_effective_median_size")]
        public uint NextBlockEffectiveMedianSize { get; set; }

        [JsonProperty("recommended_fee_per_byte")]
        public ulong RecommendedFeePerByte { get; set; }

        [JsonProperty("transaction_pool_version")]
        public uint TransactionPoolVersion { get; set; }

        [JsonProperty("incoming_peer_count")]
        public uint IncomingPeerCount { get; set; }

        [JsonProperty("outgoing_peer_count")]
        public uint OutgoingPeerCount { get; set; }
    }
}
