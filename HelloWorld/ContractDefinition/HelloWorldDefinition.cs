using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace HelloWorld.Contracts.HelloWorld.ContractDefinition
{


    public partial class HelloWorldDeployment : HelloWorldDeploymentBase
    {
        public HelloWorldDeployment() : base(BYTECODE) { }
        public HelloWorldDeployment(string byteCode) : base(byteCode) { }
    }

    public class HelloWorldDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b5060405161072338038061072383398101604081905261002f91610058565b600061003b82826101aa565b5050610269565b634e487b7160e01b600052604160045260246000fd5b6000602080838503121561006b57600080fd5b82516001600160401b038082111561008257600080fd5b818501915085601f83011261009657600080fd5b8151818111156100a8576100a8610042565b604051601f8201601f19908116603f011681019083821181831017156100d0576100d0610042565b8160405282815288868487010111156100e857600080fd5b600093505b8284101561010a57848401860151818501870152928501926100ed565b600086848301015280965050505050505092915050565b600181811c9082168061013557607f821691505b60208210810361015557634e487b7160e01b600052602260045260246000fd5b50919050565b601f8211156101a557600081815260208120601f850160051c810160208610156101825750805b601f850160051c820191505b818110156101a15782815560010161018e565b5050505b505050565b81516001600160401b038111156101c3576101c3610042565b6101d7816101d18454610121565b8461015b565b602080601f83116001811461020c57600084156101f45750858301515b600019600386901b1c1916600185901b1785556101a1565b600085815260208120601f198616915b8281101561023b5788860151825594840194600190910190840161021c565b50858210156102595787850151600019600388901b60f8161c191681555b5050505050600190811b01905550565b6104ab806102786000396000f3fe608060405234801561001057600080fd5b50600436106100365760003560e01c80633d7403a31461003b578063e21f37ce14610050575b600080fd5b61004e6100493660046101ed565b61006e565b005b610058610149565b60405161006591906102e4565b60405180910390f35b600080805461007c906102fe565b80601f01602080910402602001604051908101604052809291908181526020018280546100a8906102fe565b80156100f55780601f106100ca576101008083540402835291602001916100f5565b820191906000526020600020905b8154815290600101906020018083116100d857829003601f168201915b50505050509050816000908161010b9190610387565b507f0fef6941e28a1f2e3fe516a5c6ffc075fe9c7cbe153860ca76439aa8493a4f99818360405161013d929190610447565b60405180910390a15050565b60008054610156906102fe565b80601f0160208091040260200160405190810160405280929190818152602001828054610182906102fe565b80156101cf5780601f106101a4576101008083540402835291602001916101cf565b820191906000526020600020905b8154815290600101906020018083116101b257829003601f168201915b505050505081565b634e487b7160e01b600052604160045260246000fd5b6000602082840312156101ff57600080fd5b813567ffffffffffffffff8082111561021757600080fd5b818401915084601f83011261022b57600080fd5b81358181111561023d5761023d6101d7565b604051601f8201601f19908116603f01168101908382118183101715610265576102656101d7565b8160405282815287602084870101111561027e57600080fd5b826020860160208301376000928101602001929092525095945050505050565b6000815180845260005b818110156102c4576020818501810151868301820152016102a8565b506000602082860101526020601f19601f83011685010191505092915050565b6020815260006102f7602083018461029e565b9392505050565b600181811c9082168061031257607f821691505b60208210810361033257634e487b7160e01b600052602260045260246000fd5b50919050565b601f82111561038257600081815260208120601f850160051c8101602086101561035f5750805b601f850160051c820191505b8181101561037e5782815560010161036b565b5050505b505050565b815167ffffffffffffffff8111156103a1576103a16101d7565b6103b5816103af84546102fe565b84610338565b602080601f8311600181146103ea57600084156103d25750858301515b600019600386901b1c1916600185901b17855561037e565b600085815260208120601f198616915b82811015610419578886015182559484019460019091019084016103fa565b50858210156104375787850151600019600388901b60f8161c191681555b5050505050600190811b01905550565b60408152600061045a604083018561029e565b828103602084015261046c818561029e565b9594505050505056fea26469706673582212207d9e2454b412702497f47f4dc1a6eb432f04221c85540966302ec028aa43514a64736f6c63430008130033";
        public HelloWorldDeploymentBase() : base(BYTECODE) { }
        public HelloWorldDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("string", "firstmessage", 1)]
        public virtual string Firstmessage { get; set; }
    }

    public partial class MessageFunction : MessageFunctionBase { }

    [Function("message", "string")]
    public class MessageFunctionBase : FunctionMessage
    {

    }

    public partial class UpdateFunction : UpdateFunctionBase { }

    [Function("update")]
    public class UpdateFunctionBase : FunctionMessage
    {
        [Parameter("string", "newmesssage", 1)]
        public virtual string Newmesssage { get; set; }
    }

    public partial class MessagechangedEventDTO : MessagechangedEventDTOBase { }

    [Event("messagechanged")]
    public class MessagechangedEventDTOBase : IEventDTO
    {
        [Parameter("string", "oldmsg", 1, false )]
        public virtual string Oldmsg { get; set; }
        [Parameter("string", "newmsg", 2, false )]
        public virtual string Newmsg { get; set; }
    }

    public partial class MessageOutputDTO : MessageOutputDTOBase { }

    [FunctionOutput]
    public class MessageOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }


}
