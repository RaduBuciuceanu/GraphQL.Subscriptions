using System;
using System.Reactive;

namespace GraphQl.Subscriptions.Core
{
    public interface ISend
    {
        IObservable<Unit> Execute(object message);
    }
}
