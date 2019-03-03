using System;
using System.Reactive;

namespace GraphQl.Subscriptions.Core
{
    public interface ICommunicate
    {
        IObservable<Unit> Execute();
    }
}
