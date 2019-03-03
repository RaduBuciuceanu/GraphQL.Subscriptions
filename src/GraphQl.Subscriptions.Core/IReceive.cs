using System;

namespace GraphQl.Subscriptions.Core
{
    public interface IReceive
    {
        IObservable<TDto> Execute<TDto>();
    }
}
