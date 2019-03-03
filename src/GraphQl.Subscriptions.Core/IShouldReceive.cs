using System;

namespace GraphQl.Subscriptions.Core
{
    public interface IShouldReceive
    {
        IObservable<bool> Execute();
    }
}
