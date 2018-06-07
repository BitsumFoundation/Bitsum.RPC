
#pragma warning disable IDE1006

namespace Bitsum.RPC.WalletData
{
    using System.Collections.Generic;

    public class CreateTransactionData
    {
        public class Request
        {
            public class Transaction
            {
                public List<Transfer> transfers { get; set; }

                public uint anonymity { get; set; }

                public string payment_id { get; set; }
            }

            public Transaction transaction { get; set; }

            public string[] spend_addresses { get; set; }

            public string change_address { get; set; }

            public string optimization { get; set; }
        }

        public class Response 
        {
            public string binary_transaction { get; set; }

            public Transaction transaction { get; set; }
        }
    }
}
