
namespace Bitsum.RPC
{
    using System;

    public class RpcException : Exception
    {
        public RpcException(string message) : base(message) { }

        public RpcException(int code, string message) : base(message) { Code = code; }

        public int Code { get; set; }
    }
}
