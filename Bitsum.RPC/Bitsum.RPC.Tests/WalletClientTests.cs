using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitsum.RPC.Tests
{
    [TestClass]
    public class WalletClientTests
    {
        private readonly string testAddress = "Sm4CM39p2N6AYTHaGK9JzWDMZWUZ67P7tHK3u6pDHhwHZoJFSSk2FR5VLwERGf7JFDQBt9eFp4YTfMyLUPnLJc6g2PhR7dd8A";

        //private readonly WalletClient client = new WalletClient("http://127.0.0.1:28082");
        private readonly WalletClient client = new WalletClient("http://127.0.0.1:20001");

        [TestMethod]
        public void GetStatusTest()
        {
            Status result = client.GetStatus().Result;
            Debug.WriteLine($"{result.TopBlockHeight}/{result.NetworkHeight}");
        }

        [TestMethod]
        public void GetAddressesTest()
        {
            var result = client.GetAddresses().Result;
            Debug.WriteLine($"First address: {result[0]}");
        }

        [TestMethod]
        public void CreateAddressTest()
        {
            var result = client.CreateAddress().Result;
            Debug.WriteLine($"Created address: {result}");
        }

        [TestMethod]
        public void GetBalanceTest()
        {
            var result = client.GetBalance().Result;
            Debug.WriteLine($"Spandable: {result.Spendable}, SpandableDust: {result.SpendableDust}, Locked: {result.Locked}, Total: {result.Total}");
        }

        [TestMethod]
        public void GetBalanceForAddressTest()
        {
            var result = client.GetBalance(testAddress).Result;
            Debug.WriteLine($"Spandable: {result.Spendable}, SpandableDust: {result.SpendableDust}, Locked: {result.Locked}, Total: {result.Total}");
        }

        [TestMethod]
        public void CreateTransactionTest()
        {
            string payer = testAddress;
            string payee = testAddress;
            var result = client.CreateTransaction(payer, payee, 1).Result;
            Debug.WriteLine($"Hash: {result.Hash}\nTX: {result.TransactionHex}");
        }

        [TestMethod]
        public void SendTransactionTest()
        {
            string tx = "";
            var result = client.SendTransaction(tx).Result;
            Debug.WriteLine($"Result: {result}");
        }

        [TestMethod]
        public void GetTransfersTest()
        {
            var result = client.GetTransfersFromBlock(158980).Result;
            Debug.WriteLine($"TX Count: {result.Count}");
        }
    }
}
