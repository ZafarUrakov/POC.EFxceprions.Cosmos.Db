using System.Net;
using System;
using Xunit;
using Moq;
using EFxceptions.Cosmos.Brokers;
using EFxceptions.Cosmos.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.Cosmos;
using EFxceptions.Cosmos.Models.Exceptions;
using System.Runtime.Serialization;
using Tynamix.ObjectFiller;

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
        public void ShouldThrowConflictException()
        {
            // given
            var randomErrorMessage = CreateRandomErrorMessage();
            CosmosException cosmosException = CreateException(randomErrorMessage);
            var exception = new Exception(cosmosException.Message, cosmosException);

            sqlErrorBrokerMock.Setup(broker => broker.GetErrorCode(It.IsAny<CosmosException>()))
                .Returns(HttpStatusCode.Conflict);

            // when . then
            Assert.Throws<ConflictException>(() => efxceptionService.ThrowMeaningfulException(exception));
        }

        private CosmosException CreateException(string randomMessage)
        {
            return new CosmosException(randomMessage, HttpStatusCode.Conflict, 0, randomMessage, 0);
        }

        private string CreateRandomErrorMessage() => new MnemonicString().GetValue();
    }
}
