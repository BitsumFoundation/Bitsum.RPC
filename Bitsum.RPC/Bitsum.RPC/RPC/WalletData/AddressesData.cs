
#pragma warning disable IDE1006

namespace Bitsum.RPC.WalletData
{
    using System.Collections.Generic;

    public class AddressesData
    {
        public class Request
        {
        }

        public class Response 
        {
            public List<string> addresses { get; set; }

            public bool view_only { get; set; }
        }
    }
}
