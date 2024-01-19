// ---------------------------------------------------------------
// Copyright (c) T. Jamshid & U. Zafar
// All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Net;
using EFxceptions.Cosmos.Brokers;
using Microsoft.Azure.Cosmos;

namespace EFxceptions.Cosmos.Services
{
    public partial class EFxceptionService : IEFxceptionService
    {
        private readonly ICosmosDbBroker errorBroker;

        public EFxceptionService(ICosmosDbBroker errorBroker) =>
            this.errorBroker = errorBroker;

        public void ThrowMeaningfulException(Exception exception)
        {
            ValidateInnerException(exception);
            CosmosException cosmosException = GetException(exception.InnerException);
            HttpStatusCode httpStatusCode = this.errorBroker.GetErrorCode(cosmosException);
            ConvertAndThrowMeaningfulException(httpStatusCode, cosmosException.Message);

            throw exception;
        }

        private CosmosException GetException(Exception exception) => (CosmosException)exception;
    }
}
