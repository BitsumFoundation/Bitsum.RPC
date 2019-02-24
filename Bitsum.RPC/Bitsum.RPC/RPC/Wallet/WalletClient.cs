
namespace Bitsum.RPC.Wallet
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WalletData;

    public class WalletClient : RpcClientBase
    {
        public WalletClient(string uri) : base(uri + "/json_rpc") { }

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
                TopBlockHeight = response.Result.top_block_height,
                NetworkHeight = response.Result.top_known_block_height,
            };

            return res;
        }

        public async Task<List<string>> GetAddresses()
        {
            AddressesData.Request arg = new AddressesData.Request()
            {
            };

            RpcRequest<AddressesData.Request> request = new RpcRequest<AddressesData.Request>()
            {
                Method = "get_addresses",
                Arguments = arg
            };

            RpcResponse<AddressesData.Response> response = await PostAsync<RpcResponse<AddressesData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            return response.Result.addresses;
        }

        public async Task<string> CreateAddress()
        {
            CreateAddressData.Request arg = new CreateAddressData.Request()
            {
                secret_spend_keys = new List<string>() { string.Empty }
            };

            RpcRequest<CreateAddressData.Request> request = new RpcRequest<CreateAddressData.Request>()
            {
                Method = "create_addresses",
                Arguments = arg
            };

            RpcResponse<CreateAddressData.Response> response = await PostAsync<RpcResponse<CreateAddressData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            return response.Result.addresses[0];
        }

        public async Task<Balance> GetBalance()
        {
            return await GetBalance(string.Empty);
        }

        public async Task<Balance> GetBalance(string address)
        {
            BalanceData.Request arg = new BalanceData.Request()
            {
                address = address
            };

            RpcRequest<BalanceData.Request> request = new RpcRequest<BalanceData.Request>()
            {
                Method = "get_balance",
                Arguments = arg
            };

            RpcResponse<BalanceData.Response> response = await PostAsync<RpcResponse<BalanceData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            Balance res = new Balance()
            {
                Spendable = response.Result.spendable,
                SpendableDust = response.Result.spendable_dust,
                Locked = response.Result.locked_or_unconfirmed
            };

            return res;
        }

        public async Task<string> GetKeys(string address)
        {
            KeysData.Request arg = new KeysData.Request()
            {
                Address = address
            };

            RpcRequest<KeysData.Request> request = new RpcRequest<KeysData.Request>()
            {
                Method = "get_keys",
                Arguments = arg
            };

            RpcResponse<KeysData.Response> response = await PostAsync<RpcResponse<KeysData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            return response.Result.Keys;
        }

        public async Task<Transaction> CreateTransaction(string spendAddress, string transferAddress, long amount,
            uint anonymity = 6, string paymentId = "", OptimizationLevel optimization = OptimizationLevel.Normal)
        {
            string o;
            switch (optimization)
            {
                case OptimizationLevel.Minimal:
                    o = "minimal";
                    break;
                case OptimizationLevel.Aggressive:
                    o = "aggressive";
                    break;
                default:
                    o = string.Empty;
                    break;
            }

            CreateTransactionData.Request arg = new CreateTransactionData.Request()
            {
                spend_addresses = new string[] { spendAddress },
                change_address = spendAddress,
                optimization = o,
                transaction = new CreateTransactionData.Request.Transaction()
                {
                    anonymity = anonymity,
                    payment_id = paymentId ?? string.Empty,
                    transfers = new List<Transfer>(1)
                    {
                        new Transfer()
                        {
                            Address = transferAddress,
                            Amount = amount
                        }
                    }
                }
            };

            RpcRequest<CreateTransactionData.Request> request = new RpcRequest<CreateTransactionData.Request>()
            {
                Method = "create_transaction",
                Arguments = arg
            };

            RpcResponse<CreateTransactionData.Response> response = await PostAsync<RpcResponse<CreateTransactionData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            Transaction res = response.Result.transaction;
            res.TransactionHex = response.Result.binary_transaction;

            return res;
        }

        public async Task<bool> SendTransaction(string transactionHex)
        {
            SendTransactionData.Request arg = new SendTransactionData.Request()
            {
                binary_transaction = transactionHex
            };

            RpcRequest<SendTransactionData.Request> request = new RpcRequest<SendTransactionData.Request>()
            {
                Method = "send_transaction",
                Arguments = arg
            };

            RpcResponse<SendTransactionData.Response> response = await PostAsync<RpcResponse<SendTransactionData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            if (response.Result.send_result == "broadcast") return true;

            return false;
        }

        public async Task<List<Transaction>> GetTransfersFromBlock(uint height)
        {
            if (height > 0) height--;

            GetTransfersData.Request arg = new GetTransfersData.Request()
            {
                from_height = height,
                to_height = height + 1
            };

            RpcRequest<GetTransfersData.Request> request = new RpcRequest<GetTransfersData.Request>()
            {
                Method = "get_transfers",
                Arguments = arg
            };

            RpcResponse<GetTransfersData.Response> response = await PostAsync<RpcResponse<GetTransfersData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            if (response.Result.blocks != null && response.Result.blocks.Count > 0)
            {
                return response.Result.blocks[0].transactions;
            }

            return new List<Transaction>();
        }

        public async Task<List<Transaction>> GetTransfersFromPool()
        {
            var status = await GetStatus();

            GetTransfersData.Request arg = new GetTransfersData.Request()
            {
                from_height = status.NetworkHeight - 1,
                to_height = uint.MaxValue
            };

            RpcRequest<GetTransfersData.Request> request = new RpcRequest<GetTransfersData.Request>()
            {
                Method = "get_transfers",
                Arguments = arg
            };

            RpcResponse<GetTransfersData.Response> response = await PostAsync<RpcResponse<GetTransfersData.Response>>(request, Uri);

            if (response.Error != null)
            {
                throw new RpcException(response.Error.Message);
            }

            if (response.Result.blocks != null && response.Result.blocks.Count > 0)
            {
                return response.Result.blocks[0].transactions;
            }

            return new List<Transaction>();
        }
    }
}
