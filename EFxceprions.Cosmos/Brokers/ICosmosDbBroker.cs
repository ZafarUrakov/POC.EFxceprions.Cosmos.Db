using Microsoft.Azure.Cosmos;
using System.Net;

namespace EFxceptions.Cosmos.Brokers
{
    public interface ICosmosDbBroker
    {
        HttpStatusCode GetErrorCode(CosmosException exception);
    }
}

