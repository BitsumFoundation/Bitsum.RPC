using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitsum.RPC.Tests
{
    using Wallet;

    [TestClass]
    public class WalletClientTests
    {
        //private readonly string testAddress = "Sm4CM39p2N6AYTHaGK9JzWDMZWUZ67P7tHK3u6pDHhwHZoJFSSk2FR5VLwERGf7JFDQBt9eFp4YTfMyLUPnLJc6g2PhR7dd8A";
        //private readonly string testAddress = "Sm3ZBUMVMTV8sTfAeeLgz5cHB3sbF8yc8drWV8fWpYCRTmXxX23GU3DUM9LXLd1zMsa5J5eKYtWVGQEEz4oGRK2D2kaXQsHsu";
        private readonly string testAddress = "Sm483pMkk5QgXS1GbdYHimXx5DfzozZ74dhoc6F9qnHoHtDemJKKk2hEv4CFFM6iTK1DV2ivhx2S1cipxaXJmNPR1L9tJB8a3";

        private readonly WalletClient client = new WalletClient("http://127.0.0.1:25000");
        //private readonly WalletClient client = new WalletClient("http://127.0.0.1:20001");

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
        public void GetKeysTest()
        {
            var result = client.GetKeys(testAddress).Result;
            Debug.WriteLine($"Keys: {result}");
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
            var result = client.GetTransfersFromBlock(190319).Result;
            Debug.WriteLine($"TX Count: {result.Count}");
        }

        [TestMethod]
        public void GetTransfersTest2()
        {
            var status = client.GetStatus().Result;

            var result = client.GetTransfersFromBlock(status.TopBlockHeight + 1).Result;
            Debug.WriteLine($"TX Count: {result.Count}");
        }
    }
}
