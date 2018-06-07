
#pragma warning disable IDE1006

namespace Bitsum.RPC.PoolData
{
    public class StatsData
    {
        public class Request
        {
        }

        public class Response
        {
            public PoolStats stats { get; set; }

            public string error { get; set; }
        }
    }
}
