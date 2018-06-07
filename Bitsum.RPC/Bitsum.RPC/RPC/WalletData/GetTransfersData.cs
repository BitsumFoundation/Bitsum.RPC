
#pragma warning disable IDE1006

namespace Bitsum.RPC.WalletData
{
    using System.Collections.Generic;

    class GetTransfersData
    {
        public class Request
        {
            public uint from_height { get; set; }

            public uint to_height { get; set; }
        }

        public class Response
        {
            public class Header
            {
                uint height { get; set; }

                string hash { get; set; }
            }

            public class Block
            {
                public Header header { get; set; }

                public List<Transaction> transactions { get; set; }
            }

            public List<Block> blocks { get; set; }
        }
    }
}
