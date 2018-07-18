
namespace Bitsum.RPC.Cmc
{
    using System.Threading.Tasks;
    using Internal;

    public class CmcClient : RpcClientBase
    {
        public CmcClient() : base("https://api.coinmarketcap.com/v2/ticker/2648?convert=BTC") { }

        public async Task<CmcData> GetData()
        {
            var res = await GetAsync<Response>(this.Uri);
            return res.Data;
        }
    }
}
