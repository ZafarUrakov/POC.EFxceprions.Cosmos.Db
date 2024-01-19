﻿using System;
using Microsoft.EntityFrameworkCore;

namespace EFxceptions.Cosmos.Services
{
    public partial class EFxceptionService
    {
        private void ValidateInnerException(Exception exception)
        {
            if (exception.InnerException == null)
            {
                throw exception;
            }
        }
    }
}
