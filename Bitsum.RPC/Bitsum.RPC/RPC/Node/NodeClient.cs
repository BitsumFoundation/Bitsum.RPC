
namespace Bitsum.RPC.Node
{
    using Internal;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using NodeData;

    public class NodeClient : RpcClientBase
    {
        public NodeClient(string uri) : base(uri + "/json_rpc") { }

        public async Task<Status> GetStatus()
        {
            GetStatusData.Request arg = new GetStatusData.Request()
            {
            };

            RpcRequest<GetStatusData.Request> request = new RpcRequest<GetStatusData.Request>()
            {
                Method = "get_status",
                Arguments = arg
            };

            RpcResponse<GetStatusData.Response> response = await PostAsync<RpcResponse<GetStatusData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Code, response.Error.Message);
            }

            Status res = response.Result;

            return res;
        }

        public async Task<Block> GetBlock(ulong height)
        {
            RpcRequest<GetBlockData.Request> request = new RpcRequest<GetBlockData.Request>()
            {
                Method = "get_block_json",
                Arguments = new GetBlockData.Request() { Height = height }
            };

            RpcResponse<GetBlockData.Response> response =
                await PostAsync<RpcResponse<GetBlockData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            return response.Result.Block;
        }

        public async Task<Block> GetBlock(string hash)
        {
            RpcRequest<GetBlockData.Request> request = new RpcRequest<GetBlockData.Request>()
            {
                Method = "get_block_json",
                Arguments = new GetBlockData.Request() { Hash = hash }
            };

            RpcResponse<GetBlockData.Response> response =
                await PostAsync<RpcResponse<GetBlockData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            return response.Result.Block;
        }

        public async Task<Transaction> GetTransaction(string hash)
        {
            RpcRequest<GetTransactionData.Request> request = new RpcRequest<GetTransactionData.Request>()
            {
                Method = "get_transaction_json",
                Arguments = new GetTransactionData.Request() { Hash = hash }
            };

            RpcResponse<GetTransactionData.Response> response =
                await PostAsync<RpcResponse<GetTransactionData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            Transaction result = new Transaction()
            {
                FromBlock = response.Result.Block,
                AmountIn = response.Result.TransactionDetails.AmountIn,
                AmountOut = response.Result.TransactionDetails.AmountOut,
                Fee = response.Result.TransactionDetails.Fee,
                Extra = response.Result.Transaction.Extra,
                Hash = response.Result.TransactionDetails.Hash,
                Mixin = response.Result.TransactionDetails.Mixin,
                PaymentId = response.Result.TransactionDetails.PaymentId,
                Size = response.Result.TransactionDetails.Size,
                UnlockTime = response.Result.Transaction.UnlockTime,
                Version = response.Result.Transaction.Version
            };

            return result;
        }

        public async Task<List<TransactionPreview>> GetTransactionsPool()
        {
            GetTransactionsPoolData.Request arg = new GetTransactionsPoolData.Request() { };

            RpcRequest<GetTransactionsPoolData.Request> request = new RpcRequest<GetTransactionsPoolData.Request>()
            {
                Method = "get_mempool_json",
                Arguments = arg
            };

            RpcResponse<GetTransactionsPoolData.Response> response = await PostAsync<RpcResponse<GetTransactionsPoolData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Code, response.Error.Message);
            }

            List<TransactionPreview> result = response.Result.Transactions;

            return result;
        }
    }
}
