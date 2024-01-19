using System.Net;
using Microsoft.Azure.Cosmos;

namespace EFxceptions.Cosmos.Brokers
{
    public interface ICosmosDbBroker
    {
        HttpStatusCode GetErrorCode(CosmosException exception);
    }
}

