
namespace Bitsum.RPC
{
    public enum OptimizationLevel
    {
        /// <summary>
        /// RX < TX
        /// </summary>
        Minimal,

        /// <summary>
        /// RX = TX
        /// </summary>
        Normal,

        /// <summary>
        /// RX > TX
        /// </summary>
        Aggressive
    }
}
