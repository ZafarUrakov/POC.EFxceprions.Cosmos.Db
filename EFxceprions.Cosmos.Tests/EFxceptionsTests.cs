// ---------------------------------------------------------------
// Copyright (c) T. Jamshid & U. Zafar
// All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Net;
using EFxceptions.Cosmos.Brokers;
using EFxceptions.Cosmos.Models.Exceptions;
using EFxceptions.Cosmos.Services;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Moq;
using Tynamix.ObjectFiller;
using Xunit;

namespace EFxceptions.Cosmos.Tests
{
    public class EFxceptionsTests
    {
        private readonly Mock<ICosmosDbBroker> sqlErrorBrokerMock;
        private readonly IEFxceptionService efxceptionService;

        public EFxceptionsTests()
        {
            this.sqlErrorBrokerMock = new Mock<ICosmosDbBroker>();

            this.efxceptionService = new EFxceptionService(
                errorBroker: this.sqlErrorBrokerMock.Object);
        }

        [Fact]
        public void ShouldThrowDuplicateKeyException()
        {
            // given
            string randomErrorMessage = CreateRandomErrorMessage();
            CosmosException cosmosException = CreateException(randomErrorMessage);
            DbUpdateException exception = new DbUpdateException(cosmosException.Message, cosmosException);

            sqlErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(It.IsAny<CosmosException>()))
                    .Returns(HttpStatusCode.Conflict);

            // when . then
            Assert.Throws<DuplicateKeyException>(() =>
                efxceptionService.ThrowMeaningfulException(exception));
        }

        private CosmosException CreateException(string randomMessage)
        {
            return new CosmosException(randomMessage,
                HttpStatusCode.Conflict, 1, randomMessage, 0);
        }

        private string CreateRandomErrorMessage() => new MnemonicString().GetValue();
    }
}
