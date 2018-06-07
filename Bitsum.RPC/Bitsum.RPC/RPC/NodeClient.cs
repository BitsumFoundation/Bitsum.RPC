
namespace Bitsum.RPC
{
    using System.Threading.Tasks;
    using NodeData;

    public class NodeClient : RpcClientBase
    {
        public NodeClient(string uri) : base(uri + "/json_rpc") { }

        public async Task<Status> GetStatus()
        {
            StatusData.Request arg = new StatusData.Request()
            {
            };

            RpcRequest<StatusData.Request> request = new RpcRequest<StatusData.Request>()
            {
                Method = "get_status",
                Arguments = arg
            };

            RpcResponse<StatusData.Response> response = await PostAsync<RpcResponse<StatusData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Code, response.Error.Message);
            }

            Status res = new Status()
            {
                LocalHeight = response.Result.top_block_height,
                GlobalHeight = response.Result.top_known_block_height,
            };

            return res;
        }

    }
}
