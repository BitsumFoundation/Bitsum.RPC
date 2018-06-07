
#pragma warning disable IDE1006

namespace Bitsum.RPC.WalletData
{
    internal class BalanceData
    {
        public class Request
        {
            public string address { get; set; }

            public int height_or_depth { get; set; } = -6;
        }

        public class Response
        {
            public ulong spendable { get; set; }

            public ulong spendable_dust { get; set; }

            public ulong locked_or_unconfirmed { get; set; }
        }
    }
}
