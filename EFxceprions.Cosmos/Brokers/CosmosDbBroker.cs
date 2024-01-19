using System.Net;
using Microsoft.Azure.Cosmos;

namespace EFxceptions.Cosmos.Brokers
{
    public class CosmosDbBroker : ICosmosDbBroker
    {
        public HttpStatusCode GetErrorCode(CosmosException exception) => exception.StatusCode;
    }
}
