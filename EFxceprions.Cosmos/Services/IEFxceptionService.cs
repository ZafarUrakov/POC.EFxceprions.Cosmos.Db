using System;

namespace EFxceptions.Cosmos.Services
{
    public interface IEFxceptionService
    {
        void ThrowMeaningfulException(Exception exception);
    }
}
