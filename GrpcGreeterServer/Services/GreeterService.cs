using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcGreeterServer
{
    #region snippet
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name,
            });
        }

        public override Task<HelloReply> SayHelloNew(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "HelloNew " + request.Name
            });
        }

        public override Task<RPCModel> SayInt(RPCRequest request, ServerCallContext context)
        {
            return Task.FromResult(new RPCModel
            {
                Query = request.Query + 1,
                Count = request.Count + 1,
            });
        }
    }
    #endregion
}
