
#pragma warning disable IDE1006

namespace Bitsum.RPC.WalletData
{
    using System.Collections.Generic;

    internal class CreateAddressData
    {
        public class Request
        {
            public List<string> secret_spend_keys { get; set; }

            public uint creation_timestamp { get; set; } = 0;
        }

        public class Response
        {
            public List<string> secret_spend_keys { get; set; }

            public List<string> addresses { get; set; }
        }
    }
}
