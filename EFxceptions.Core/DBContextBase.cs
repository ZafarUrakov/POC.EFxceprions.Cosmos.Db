// ---------------------------------------------------------------
// Copyright (c) T. Jamshid & U. Zafar
// All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using EFxceptions.Cosmos.Brokers;
using EFxceptions.Cosmos.Services;
using Microsoft.EntityFrameworkCore;

namespace EFxceptions.Core
{
    public abstract class DBContextBase : DbContext
    {
        private IEFxceptionService eFxceptionService;
        private ICosmosDbBroker errorBroker;

        protected DBContextBase() =>
            InitializeInternalServices();

        public DBContextBase(DbContextOptions options) : base(options) =>
            InitializeInternalServices();

        private void InitializeInternalServices()
        {
            this.errorBroker = CreateErrorBroker();
            this.eFxceptionService = CreateEFxceptionService(this.errorBroker);
        }

        protected abstract ICosmosDbBroker CreateErrorBroker();
        protected abstract IEFxceptionService CreateEFxceptionService(
            ICosmosDbBroker errorBroker);

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                this.eFxceptionService.ThrowMeaningfulException(
                    exception);

                throw;
            }
        }

        public override async Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            }
            catch (Exception exception)
            {
                this.eFxceptionService.ThrowMeaningfulException(exception);

                throw;
            }
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception exception)
            {
                this.eFxceptionService.ThrowMeaningfulException(exception);

                throw;
            }
        }

        public override int SaveChanges(
            bool acceptAllChangesOnSuccess)
        {
            try
            {
                return base.SaveChanges(acceptAllChangesOnSuccess);
            }
            catch (Exception exception)
            {
                this.eFxceptionService.ThrowMeaningfulException(exception);

                throw;
            }
        }
    }
}
