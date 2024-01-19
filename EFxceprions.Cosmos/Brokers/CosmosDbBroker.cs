// ---------------------------------------------------------------
// Copyright (c) T. Jamshid & U. Zafar
// All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Net;
using Microsoft.Azure.Cosmos;

namespace EFxceptions.Cosmos.Brokers
{
    public class CosmosDbBroker : ICosmosDbBroker
    {
        public HttpStatusCode GetErrorCode(CosmosException exception) => exception.StatusCode;
    }
}
