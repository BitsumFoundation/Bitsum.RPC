
namespace Bitsum.RPC
{
    public class Balance
    {
        public ulong Spendable { get; set; }

        public ulong SpendableDust { get; set; }

        public ulong Locked { get; set; }

        public ulong Total { get { return Spendable + SpendableDust + Locked; } }
    }
}
