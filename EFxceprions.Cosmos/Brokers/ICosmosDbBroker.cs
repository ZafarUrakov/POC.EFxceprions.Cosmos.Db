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
    public interface ICosmosDbBroker
    {
        HttpStatusCode GetErrorCode(CosmosException exception);
    }
}

