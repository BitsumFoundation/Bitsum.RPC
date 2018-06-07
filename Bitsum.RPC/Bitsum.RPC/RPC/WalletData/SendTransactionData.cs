
#pragma warning disable IDE1006

namespace Bitsum.RPC.WalletData
{
    public class SendTransactionData
    {
        public class Request
        {
            public string binary_transaction { get; set; }
        }

        public class Response
        {
            public string send_result { get; set; }
        }
    }
}
