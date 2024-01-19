using System;
using System.Net;
using EFxceptions.Cosmos.Models.Exceptions;

namespace EFxceptions.Cosmos.Services
{
    public partial class EFxceptionService
    {
        private void ConvertAndThrowMeaningfulException(HttpStatusCode statusCode, string message)
        {
            switch (statusCode)
            {
                case HttpStatusCode.Conflict:
                    throw new ConflictException(message);
            }
        }

    }
}
