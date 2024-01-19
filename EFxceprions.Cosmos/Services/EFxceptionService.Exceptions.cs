// ---------------------------------------------------------------
// Copyright (c) T. Jamshid & U. Zafar
// All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

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
                    throw new DuplicateKeyException(message);
            }
        }
    }
}
