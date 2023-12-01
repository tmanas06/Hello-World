using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using HelloWorld.Contracts.HelloWorld.ContractDefinition;

namespace HelloWorld.Contracts.HelloWorld
{
    public partial class HelloWorldService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, HelloWorldDeployment helloWorldDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<HelloWorldDeployment>().SendRequestAndWaitForReceiptAsync(helloWorldDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, HelloWorldDeployment helloWorldDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<HelloWorldDeployment>().SendRequestAsync(helloWorldDeployment);
        }

        public static async Task<HelloWorldService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, HelloWorldDeployment helloWorldDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, helloWorldDeployment, cancellationTokenSource);
            return new HelloWorldService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public HelloWorldService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public HelloWorldService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> MessageQueryAsync(MessageFunction messageFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MessageFunction, string>(messageFunction, blockParameter);
        }

        
        public Task<string> MessageQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MessageFunction, string>(null, blockParameter);
        }

        public Task<string> UpdateRequestAsync(UpdateFunction updateFunction)
        {
             return ContractHandler.SendRequestAsync(updateFunction);
        }

        public Task<TransactionReceipt> UpdateRequestAndWaitForReceiptAsync(UpdateFunction updateFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateFunction, cancellationToken);
        }

        public Task<string> UpdateRequestAsync(string newmesssage)
        {
            var updateFunction = new UpdateFunction();
                updateFunction.Newmesssage = newmesssage;
            
             return ContractHandler.SendRequestAsync(updateFunction);
        }

        public Task<TransactionReceipt> UpdateRequestAndWaitForReceiptAsync(string newmesssage, CancellationTokenSource cancellationToken = null)
        {
            var updateFunction = new UpdateFunction();
                updateFunction.Newmesssage = newmesssage;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateFunction, cancellationToken);
        }
    }
}
