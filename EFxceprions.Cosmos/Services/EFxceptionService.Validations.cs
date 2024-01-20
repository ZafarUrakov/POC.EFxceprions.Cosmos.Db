﻿// ---------------------------------------------------------------
// Copyright (c) T. Jamshid & U. Zafar
// All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore;

namespace EFxceptions.Cosmos.Services
{
    public partial class EFxceptionService
    {
        private void ValidateInnerException(DbUpdateException exception)
        {
            if (exception.InnerException == null)
            {
                throw exception;
            }
        }
    }
}
