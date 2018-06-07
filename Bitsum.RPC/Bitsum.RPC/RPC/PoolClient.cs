
namespace Bitsum.RPC
{
    using System.Threading.Tasks;
    using PoolData;

    //http://pool.bitsum.uz:8117/stats_address?address=%address%&longpoll=true
    public class PoolClient : RpcClientBase
    {
        public PoolClient(string uri) : base(uri)
        {
        }

        public async Task<PoolStats> GetStatus(string address)
        {
            string uri = Uri + $"stats_address?address={address}";

            StatsData.Response response = await GetAsync<StatsData.Response>(uri);

            return response.stats;
        }
    }
}
